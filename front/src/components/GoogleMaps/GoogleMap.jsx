import React, {useEffect, useState, useRef, useCallback, forwardRef, useContext} from 'react';
import {MarkerClusterer} from '@googlemaps/markerclusterer';
import {Circle} from '../Circle';
import {Poi} from '../../models/Poi';
import shrek from '../../assets/shrek.jpg';
import {AppStateContext} from "../../context/AppStateProvider";
import {
  mapI,
  AdvancedMarkerElementWrapper,
  pinElement, 
  infoWindow,
 } from '../../utils/GoogleMapsObjects';

const GoogleMap = ({mapResponseItems, selectedItemId, setSelectedItemId}) => {
  const {
    selectedDates,
    selectedMapDateResults,
    // map, 
    // setMap,
  } = useContext(AppStateContext);

  const colors = ['#D72638', '#3F88C5', '#F49D37', '#9842f5', '#1aba1a'];
  const secondaryColors = ['#9E1A2B', '#2B6390', '#C27A2D', '#752EB2', '#148114'];

  const [pois, setPois] = useState({});  
  const [map, setMap] = useState(null);
  const [markers, setMarkers] = useState([]);

  const handleMarkerClick = useCallback(
    (ev, markerId) => {
      console.log('marker clicked:', markerId);
      if (!map) return;
      if (!ev.latLng) return;
      console.log('marker clicked:', markerId, ev.latLng.toString());
      setSelectedItemId(markerId);
    },
    [map, setSelectedItemId]
  );

  const handleMarkerHover = useCallback(
    (ev, marker, markerId, popupPicture, isHovered) => {
        // console.log('marker hovered:', markerId);
        // if (!map) return;

        const rootFontSize = parseFloat(getComputedStyle(document.documentElement).fontSize);
    
        // Convert rem to pixels
        const popupWidth = 14 * rootFontSize; // 14rem to pixels
        const popupHeight = 10 * rootFontSize; // 10rem to pixels
        const offset = 3 * rootFontSize; // 3rem to pixels
  
        const projection = map.getProjection();
        const position = marker.position;
        const topRight = projection.fromLatLngToPoint(map.getBounds().getNorthEast()); 
        const bottomLeft = projection.fromLatLngToPoint(map.getBounds().getSouthWest());
        
        const scale = Math.pow(2, map.getZoom());
        const pixelOffset = {
          x: offset / scale,
          y: offset / scale,
        };

        const point = projection.fromLatLngToPoint(position);
        var posLeft = (point.x - bottomLeft.x) * scale;
        var posTop = (point.y - topRight.y) * scale;
        var pointPixCoord = { x: posLeft, y: posTop };

        
        const mapDiv = map.getDiv();
        const mapBounds = mapDiv.getBoundingClientRect();
    
        let popupPosition = 'above';
    
        const checkPopupFitTop = (pointPixCoord, popupHeight, offset, mapBounds) => {
          return pointPixCoord.y - popupHeight - offset > mapBounds.top;
        };

        const checkPopupFitRight = (pointPixCoord, popupWidth, offset, mapBounds) => {
          return pointPixCoord.x + popupWidth + offset <= mapBounds.right;
        };

        const checkPopupFitBottom = (pointPixCoord, popupHeight, offset, mapBounds) => {
          return pointPixCoord.y + popupHeight + offset <= mapBounds.bottom;
        };

        const checkPopupFitLeft = (pointPixCoord, popupWidth, offset, mapBounds) => {
          return pointPixCoord.x - popupWidth - offset >= mapBounds.left;
        };

        if (
          checkPopupFitTop(pointPixCoord, popupHeight, offset, mapBounds) &&
          checkPopupFitRight(pointPixCoord, popupWidth, offset, mapBounds) &&
          checkPopupFitLeft(pointPixCoord, popupWidth, offset, mapBounds)
        ) {
          popupPosition = 'above';
        } else if (
          checkPopupFitRight(pointPixCoord, popupWidth, offset, mapBounds) &&
          checkPopupFitBottom(pointPixCoord, popupHeight, offset, mapBounds) &&
          checkPopupFitTop(pointPixCoord, popupHeight, offset, mapBounds)
        ) {
          popupPosition = 'right';
        } else if (
          checkPopupFitBottom(pointPixCoord, popupHeight, offset, mapBounds) &&
          checkPopupFitRight(pointPixCoord, popupWidth, offset, mapBounds) &&
          checkPopupFitLeft(pointPixCoord, popupWidth, offset, mapBounds)
        ) {
          popupPosition = 'below';
        } else if (
          checkPopupFitLeft(pointPixCoord, popupWidth, offset, mapBounds) &&
          checkPopupFitBottom(pointPixCoord, popupHeight, offset, mapBounds) &&
          checkPopupFitTop(pointPixCoord, popupHeight, offset, mapBounds)
        ) {
          popupPosition = 'left';
        }
  
        if (isHovered) {
          const headerDiv = document.createElement('div');
          headerDiv.innerHTML = `${markerId}`;
          infoWindow.setHeaderContent(headerDiv);
          infoWindow.setContent(`<img src="${popupPicture}" alt="Popup Picture" class="map-popup-image"/>`);

          let newPosition;
          switch (popupPosition) {
            case 'above':
                newPosition = projection.fromPointToLatLng(new google.maps.Point(point.x, point.y - pixelOffset.y));
                break;
              case 'below':
                newPosition = projection.fromPointToLatLng(new google.maps.Point(point.x, point.y + pixelOffset.y*5));
                break;
              case 'left':
                newPosition = projection.fromPointToLatLng(new google.maps.Point(point.x - pixelOffset.x*3.5, point.y));
                break;
              case 'right':
                newPosition = projection.fromPointToLatLng(new google.maps.Point(point.x + pixelOffset.x*3.5, point.y));
              break;
          }

          infoWindow.setPosition(newPosition);
          infoWindow.open(map);
        } else {
            infoWindow.close();
        }
    }, 
    [map, infoWindow]
  );

  // initialize map on mount
  useEffect(() => {
    const initializeMap = async () => {
      const center = {lat: 40.701119399999996, lng: -111}; // Example center
      const mapId = 'the friggin map';
      const zoom = 8;
      const gestureHandling = 'greedy';
      const disableDefaultUI = true;

      const map = await mapI(center, mapId, zoom, gestureHandling, disableDefaultUI);
      setMap(map);
    };

    if (document.getElementById('map_yeet')) {
      initializeMap();
      // console.log('initilize map hit');
    }
  }, []);

  //initialize pois on mount 
  useEffect(() => {    
    const pois_ = {};
    let i = 0;
    for (const responseItem of Object.values(mapResponseItems)) {
      // if (!selectedDates.includes(responseItem.date.name)) {
      //   i++;
      //   continue;
      // }
      for (const result of responseItem.results) {
        pois_[result.displayName] = new Poi(
          result.displayName,
          result.latLng.latitude,
          result.latLng.longitude,
          responseItem.date.name,
          colors[i], 
          secondaryColors[i],
          result.photos && result.photos.length > 0 ? result.photos[0].photoUri : shrek
        );
      }
      i++;
    }

    setPois(pois_);
    // console.log('initilize pois hit');
  }, []);

  // inititialize markers on mount, and update markers when pois changes
  useEffect(() => {
    if (!map || markers.length != 0) return;
    // Create markers for each poi
    const updateMarkers = async () => {
      const newMarkers = [];
      for (const poi of Object.values(pois)) {
        // if (!selectedDates.includes(poi.dateType)) {
        //   continue;
        // }
        const pin = await pinElement(
          poi.color, 
          poi.secondaryColor, 
          poi.secondaryColor, 
        );
        const marker = await new AdvancedMarkerElementWrapper(
          poi.location, 
          map, 
          poi.key, 
          poi.dateType,
          pin.element, 
          handleMarkerClick,
          handleMarkerHover,
          poi.picture,
          poi.color,
          poi.secondaryColor
        );
        newMarkers.push(marker);
      }
      setMarkers(newMarkers);
    };

    updateMarkers();
    // console.log('initilize markers hit');
  }, [map, pois, selectedItemId]);

  // Update markers when selectedDates or selectedMapDateResults changes 
  useEffect(() => {
    if (!map) return;

    for (const marker of markers) {
      if (selectedDates.includes(marker.dateType) 
      && selectedMapDateResults.some(result => result.displayName === marker.id)
    ) {
        marker.marker.setMap(map);
      } else {
        marker.marker.setMap(null);
      }
    }
    // console.log('update markers hit');

  }, [map, selectedDates, selectedMapDateResults, pois, markers]);

  useEffect(() => {
    if (!map) return;

    for (const marker of markers) {
      if (marker.id === selectedItemId) {
        marker.highlightMarker();
      } else if(marker.highlighted) {
        marker.unhighlightMarker();
      }
    }
  }, [selectedItemId]);



  // const poiMarkers = PoiMarkers(pois_, setSelectedItemId);
  // console.log('pois', pois);
  // console.log('selectedDates', selectedDates);  
  // console.log('mapResponseItems', mapResponseItems);
  // console.log('map', map);
  // console.log('markers', markers);
    return (
      <div id="map_yeet" style={{height: '100vh', width: '100%'}}/>
    );
};

// AdvancedMarkerElementWrapper.displayName = 'AdvancedMarkerElement';



export default GoogleMap;