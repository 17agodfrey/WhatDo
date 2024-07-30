import React, {useEffect, useState, useRef, useCallback, forwardRef} from 'react';
import {
    APIProvider,
    Map,
    AdvancedMarker,
    useMap,
    Pin,
} from '@vis.gl/react-google-maps';
import {MarkerClusterer} from '@googlemaps/markerclusterer';
import {Circle} from '../Circle';
import {Poi} from '../../models/Poi';
import { Loader } from "@googlemaps/js-api-loader"
import shrek from '../../assets/shrek.jpg';


const apiKey = process.env.REACT_APP_GOOGLE_MAPS_API_KEY;

const loader = new Loader({
  apiKey: apiKey,
  version: "weekly",
});


const AdvancedMarkerElementWrapper = forwardRef(({ position, map, onClick, onHover, id, popupPicture }, ref) => {
  useEffect(() => {
    let marker;

    // const instance = {
    //   position,
    //   map,
    //   onClick,
    //   onHover,
    //   id,
    //   popupPicture,
    // };

    loader
      .importLibrary('marker')
      .then(({ AdvancedMarkerElement, PinElement }) => {
        marker = new AdvancedMarkerElement({
          position: position,
          map: map,
          gmpClickable: true,
        });

        const pin = new PinElement({
          background: 'blue',
          scale: 2.0,
        });

        marker.appendChild(pin.element);

        if (onClick) {
          marker.addListener('click', (ev) => onClick(ev, id));
        }

        if (onHover) {
          marker.content.addEventListener('mouseover', (ev) => onHover(ev, marker, id, popupPicture, true));
          marker.content.addEventListener('mouseout', (ev) => onHover(ev, marker, id, popupPicture, false));
        }

        if (ref) {
          ref(marker);
        }
      })
      .catch((err) => {
        console.error(err);
      });

    return () => {
      if (marker) {
        marker.setMap(null);
      }
    };
  }, [position, map, onClick, onHover, ref]);

  return null;
});

// const poi = [
//     { key: 'operaHouse', location: { lat: -33.8567844, lng: 151.213108 } },
//     { key: 'tarongaZoo', location: { lat: -33.8472767, lng: 151.2188164 } },
//     { key: 'manlyBeach', location: { lat: -33.8209738, lng: 151.2563253 } },
//     { key: 'hyderPark', location: { lat: -33.8690081, lng: 151.2052393 } },
//     { key: 'theRocks', location: { lat: -33.8587568, lng: 151.2058246 } },
//     { key: 'circularQuay', location: { lat: -33.858761, lng: 151.2055688 } },
//     { key: 'harbourBridge', location: { lat: -33.852228, lng: 151.2038374 } },
//     { key: 'kingsCross', location: { lat: -33.8737375, lng: 151.222569 } },
//     { key: 'botanicGardens', location: { lat: -33.864167, lng: 151.216387 } },
//     { key: 'museumOfSydney', location: { lat: -33.8636005, lng: 151.2092542 } },
//     { key: 'maritimeMuseum', location: { lat: -33.869395, lng: 151.198648 } },
//     { key: 'kingStreetWharf', location: { lat: -33.8665445, lng: 151.1989808 } },
//     { key: 'aquarium', location: { lat: -33.869627, lng: 151.202146 } },
//     { key: 'darlingHarbour', location: { lat: -33.87488, lng: 151.1987113 } },
//     { key: 'barangaroo', location: { lat: -33.8605523, lng: 151.1972205 } },
//   ];

const PoiMarkers = ({ pois, setSelectedItemId}) => {
  const map = useMap();
  const [markers, setMarkers] = useState({});
  const clusterer = useRef(null);
  const [circleCenter, setCircleCenter] = useState(null);
  const [infoWindowOpen, setInfoWindowOpen] = useState(false);

  let infoWindow = null;
  loader.importLibrary('maps').then(({ InfoWindow }) => {
    infoWindow = new InfoWindow({
      content: "dababy",
      ariaLabel: "Uluru",
    });
  });

  // useEffect(() => {
  //   if (!map) return;
  //   if (!clusterer.current) {
  //     clusterer.current = new MarkerClusterer({ map });
  //   }
  // }, [map]);

  // useEffect(() => {
  //   clusterer.current?.clearMarkers();
  //   clusterer.current?.addMarkers(Object.values(markers));
  // }, [markers]);

  const setMarkerRef = (marker, key) => {
    // console.log('setMarkerRef hit');
    if (marker && markers[key]) return;
    if (!marker && !markers[key]) return;

    setMarkers((prev) => {
      if (marker) {
        return { ...prev, [key]: marker };
      } else {
        const newMarkers = { ...prev };
        delete newMarkers[key];
        return newMarkers;
      }
    });
  };

  const handleMarkerClick = useCallback(
    (ev, markerId) => {
      if (!map) return;
      if (!ev.latLng) return;
      console.log('marker clicked:', markerId, ev.latLng.toString());
      map.panTo(ev.latLng);
      setCircleCenter(ev.latLng);
      setSelectedItemId(markerId);
    },
    [map]
  );

  const handleMarkerHover = useCallback(
      (ev, marker, markerId, popupPicture, isHovered) => {
        // console.log('infoWindow:', infoWindow);
        // console.log('markers[markerId]: ', markers[markerId]);
        // console.log('pois: ', pois[0]);
          if (!map) return;
          if (isHovered) {
              infoWindow.setHeaderContent(`Marker ID: ${markerId}`);
              infoWindow.setContent(`<img src="${popupPicture}" alt="Popup Picture" class="map-popup-image"/>`);
              infoWindow.open(map, marker);
          } else {
              infoWindow.close();
          }
      }, [map, infoWindow, markers]
  );

  return (
    <>
      <Circle
        radius={800}
        center={circleCenter}
        strokeColor={'#0c4cb3'}
        strokeOpacity={1}
        strokeWeight={3}
        fillColor={'#3b82f6'}
        fillOpacity={0.3}
      />
      {Object.values(pois).map((poi) => (
        <AdvancedMarkerElementWrapper
          key={poi.key}
          position={poi.location}
          map={map}
          onClick={handleMarkerClick}
          onHover={handleMarkerHover}
          id={poi.key}
          popupPicture={poi.picture}
          ref={marker => setMarkerRef(marker, poi.key)}
        />
      ))}
    </>
  );
};
  

const GoogleMap = ({mapResults, mapResponseItems, setSelectedItemId}) => {
  // const pois_ = mapResults && mapResults.length > 0 ? 
  //   mapResults.map(result => new Poi(
  //     result.displayName,
  //     result.latLng.latitude,
  //     result.latLng.longitude, 
  //     result.photosUris && result.photosUris.length > 0 ? result.photosUris[0] : shrek
  //   ))
  //   : [];

  const pois_ = {};
  for (const responseItem of mapResponseItems) {
    for (const result of responseItem.results) {
      pois_[result.displayName] = new Poi(
        result.displayName,
        result.latLng.latitude,
        result.latLng.longitude,
        responseItem.date.name,
        result.photosUris && result.photosUris.length > 0 ? result.photosUris[0] : shrek
      );
    }
  }
    
    

  const [pois, setPois] = useState(pois_);    

    return (
        <APIProvider apiKey={apiKey} onLoad={() => console.log('Maps API has loaded.')}>
            <Map
                // style={{width: '100vw', height: '100vh'}}
                defaultCenter={{lat: 40.701119399999996, lng: -111}}
                mapId='DEMO_MAP_ID'
                // onCameraChanged={ (ev) =>
                //     console.log('camera changed:', ev.detail.center, 'zoom:', ev.detail.zoom)
                //   }
                defaultZoom={8}
                gestureHandling={'greedy'}
                disableDefaultUI={true}
            >
                <PoiMarkers 
                    pois={pois} 
                    setSelectedItemId={setSelectedItemId}
                />
            </Map>
        </APIProvider>
    );
}

AdvancedMarkerElementWrapper.displayName = 'AdvancedMarkerElement';



export default GoogleMap;