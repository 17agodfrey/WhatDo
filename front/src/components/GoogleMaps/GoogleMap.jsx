import React, {useEffect, useState, useRef, useCallback, forwardRef, useContext} from 'react';
// import {
//     APIProvider,
//     Map,
//     AdvancedMarker,
//     useMap,
//     Pin,
// } from '@vis.gl/react-google-maps';
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
//  import PinElement from '../PinElement';


// const infoWindow = async () => {
//   try {
//     let infoWindow = null;
//     loader.importLibrary('maps').then(({ InfoWindow }) => {
//       infoWindow = new InfoWindow({
//         content: "dababy",
//         ariaLabel: "Uluru",
//         disableAutoPan: true,
//       });
//     })
//     return infoWindow;
//   } catch (err) {
//     console.error(err);
//   }
// };





// const AdvancedMarkerElementWrapper = forwardRef(({marker, position, map, onClick, onHover, id, popupPicture, color, secondaryColor }, ref) => {
//   // const {selectedDates} = useContext(AppStateContext);
//   // const [marker, setMarker] = useState(null);

//   // const removeMarker = () => {
//   //   if (marker) {
//   //     marker.setMap(null);
//   //   }
//   // };

//   useEffect(() => {
//     // let marker;
//     // let pin; 

//     // loader
//     //   .importLibrary('marker')
//     //   .then(({ AdvancedMarkerElement, PinElement }) => {
//     //     pin = new PinElement({
//     //       background: color || 'blue',
//     //       borderColor: secondaryColor || 'white',
//     //       glyphColor: secondaryColor || 'white',
//     //     });
//     //     marker = new AdvancedMarkerElement({
//     //       position: position,
//     //       gmpClickable: true,
//     //       content: pin.element,
//     //     });

//         // if(selectedDates.includes(dateType)) {
//         //   marker.setMap(map);
//         // } else {
//         //   marker.setMap(null);
//         // }

//         // setMarker(newMarker);

//         // marker.appendChild(pin.element);

//         // marker.content = pin.element; 

//         if (onClick) {
//           marker.addListener('click', (ev) => onClick(ev, id));
//         }

//         if (onHover) {
//           marker.content.addEventListener('mouseover', (ev) => onHover(ev, marker, id, popupPicture, true));
//           marker.content.addEventListener('mouseout', (ev) => onHover(ev, marker, id, popupPicture, false));
//         }

//         if (ref) {
//           ref(marker);
//         }

//       // })
//       // .catch((err) => {
//       //   console.error(err);
//       // });

//     return () => {
//       if (marker) {
//         marker.setMap(null);
//       }
//     };
//   }, [position, map, onClick, onHover, ref]);

//   return null;
// });

// const PoiMarkers = ({ pois, setSelectedItemId}) => {
//   const {selectedDates} = useContext(AppStateContext);

//   const map = useMap('the friggin map');
//   const [markers, setMarkers] = useState([]);
//   const clusterer = useRef(null);
//   const [circleCenter, setCircleCenter] = useState(null);
//   const [infoWindowOpen, setInfoWindowOpen] = useState(false);


//   useEffect(() => {
//     if (!map) return;
    
//     //create markers for each poi
//     const updateMarkers = async () => {
//       // Remove existing markers
//       // for (const marker of markers) {
//       //   marker.setMap(null);
//       // }
  
//       const newMarkers = [];
//       for (const poi of Object.values(pois)) {
//         // const pin = await pinElement(poi.color, poi.secondaryColor, poi.secondaryColor);
//         // const marker = await advMarkerElement(poi.location, map);
//         const marker = new google.maps.Marker({
//           position: poi.location,
//           map: map,
//         });
//         newMarkers.push(marker);
//       }
  
//       setMarkers(newMarkers);
//     };
  
//     updateMarkers();

//   }, []);  


//   // let infoWindow = null;
//   // loader.importLibrary('maps').then(({ InfoWindow }) => {
//   //   infoWindow = new InfoWindow({
//   //     content: "dababy",
//   //     ariaLabel: "Uluru",
//   //     disableAutoPan: true,
//   //   });
//   // });

//   // useEffect(() => {
//   //   if (!map) return;
//   //   if (!clusterer.current) {
//   //     clusterer.current = new MarkerClusterer({ map });
//   //   }
//   // }, [map]);

//   // useEffect(() => {
//   //   clusterer.current?.clearMarkers();
//   //   clusterer.current?.addMarkers(Object.values(markers));
//   // }, [markers]);    

//   const setMarkerRef = (marker, key) => {
//     // console.log('setMarkerRef hit');
//     if (marker && markers[key]) return;
//     if (!marker && !markers[key]) return;

//     setMarkers((prev) => {
//       if (marker) {
//         return { ...prev, [key]: marker };
//       } else {
//         const newMarkers = { ...prev };
//         delete newMarkers[key];
//         return newMarkers;
//       }
//     });
//   };

//     //iterate through pois and create markers
//   useEffect(() => {
//   if (!map) return;

//   // const updateMarkers = async () => {
//     // Remove existing markers
//     for (const marker of markers) {
//       console.log('marker.map: ', marker.map);
//       marker.setMap(null);
//       // setMapOnAll(null);
//       // clearMarkers();
//       console.log('after set map, marker.map: ', marker.map);
//     }
//     console.log('markers removed');

//   //   // const newMarkers = [];
//   //   // for (const poi of Object.values(pois)) {
//   //   //   const pin = await pinElement(poi.color, poi.secondaryColor, poi.secondaryColor);
//   //   //   const marker = await advMarkerElement(poi.location, map, pin.element);
//   //   //   newMarkers.push(marker);
//   //   // }

//   //   // setMarkers(newMarkers);
//   // };

//   // updateMarkers();

//   // const newMarkers = Object.values(pois).map((poi) => (
//   //     <AdvancedMarkerElementWrapper
//   //       key={poi.key}
//   //       position={poi.location}
//   //       map={map}
//   //       onClick={handleMarkerClick}
//   //       onHover={handleMarkerHover}  
//   //       id={poi.key}
//   //       popupPicture={poi.picture}
//   //       color={poi.color}
//   //       secondaryColor={poi.secondaryColor}
//   //     />
//     // ));

//   // setMarkers(newMarkers);
//   } , [map, pois, selectedDates, markers, handleMarkerClick, handleMarkerHover]);

//   console.log('markers', markers); 
//   // console.log('markersValues')
//   // console.log('markersLen', markers.length);

//   return (
//     <>
//       {/* <Circle
//         radius={800}
//         center={circleCenter}
//         strokeColor={'#0c4cb3'}
//         strokeOpacity={1}
//         strokeWeight={3}
//         fillColor={'#3b82f6'}
//         fillOpacity={0.3}
//       /> */}
//       {/* <MarkerClusterer map={map} markers={Object.values(markers)} /> */}
//       {/* {markers.length > 0 && Object.values(markers)} */}
//       {/* {Object.values(pois)
//         .map((poi) => (
//           <AdvancedMarkerElementWrapper
//             key={poi.key}
//             position={poi.location}
//             map={map}
//             onClick={handleMarkerClick}
//             onHover={handleMarkerHover}
//             id={poi.key}
//             popupPicture={poi.picture}
//             color={poi.color}
//             secondaryColor={poi.secondaryColor}
//             ref={marker => setMarkerRef(marker, poi.key)}
//           />
//       ))} */}
//     </>
//   );
// };
  

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
      // map.panTo(ev.latLng);
      // setCircleCenter(ev.latLng);
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