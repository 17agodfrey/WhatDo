import React, {useEffect, useState, useRef, useCallback} from 'react';
import {
    APIProvider,
    Map,
    AdvancedMarker,
    useMap,
    Pin,
} from '@vis.gl/react-google-maps';
import {MarkerClusterer} from '@googlemaps/markerclusterer';
import {Circle} from './Circle';
import {Poi} from '../models/Poi';

const apiKey = process.env.REACT_APP_GOOGLE_MAPS_API_KEY;

const poi = [
    { key: 'operaHouse', location: { lat: -33.8567844, lng: 151.213108 } },
    { key: 'tarongaZoo', location: { lat: -33.8472767, lng: 151.2188164 } },
    { key: 'manlyBeach', location: { lat: -33.8209738, lng: 151.2563253 } },
    { key: 'hyderPark', location: { lat: -33.8690081, lng: 151.2052393 } },
    { key: 'theRocks', location: { lat: -33.8587568, lng: 151.2058246 } },
    { key: 'circularQuay', location: { lat: -33.858761, lng: 151.2055688 } },
    { key: 'harbourBridge', location: { lat: -33.852228, lng: 151.2038374 } },
    { key: 'kingsCross', location: { lat: -33.8737375, lng: 151.222569 } },
    { key: 'botanicGardens', location: { lat: -33.864167, lng: 151.216387 } },
    { key: 'museumOfSydney', location: { lat: -33.8636005, lng: 151.2092542 } },
    { key: 'maritimeMuseum', location: { lat: -33.869395, lng: 151.198648 } },
    { key: 'kingStreetWharf', location: { lat: -33.8665445, lng: 151.1989808 } },
    { key: 'aquarium', location: { lat: -33.869627, lng: 151.202146 } },
    { key: 'darlingHarbour', location: { lat: -33.87488, lng: 151.1987113 } },
    { key: 'barangaroo', location: { lat: -33.8605523, lng: 151.1972205 } },
  ];

  const PoiMarkers = ({pois}) => {
    const map = useMap();
    const [markers, setMarkers] = useState({});
    const clusterer = useRef(null);      
    const [circleCenter, setCircleCenter] = useState(null)

  
    // Initialize MarkerClusterer, if the map has changed
    useEffect(() => {
      if (!map) return;
      if (!clusterer.current) {
        clusterer.current = new MarkerClusterer({ map });
      }
    }, [map]);
  
    // Update markers, if the markers array has changed
    useEffect(() => {
      clusterer.current?.clearMarkers();
      clusterer.current?.addMarkers(Object.values(markers));
    }, [markers]);
  
    const setMarkerRef = (marker, key) => {
      if (marker && markers[key]) return;
      if (!marker && !markers[key]) return;
  
      setMarkers(prev => {
        if (marker) {
          return { ...prev, [key]: marker };
        } else {
          const newMarkers = { ...prev };
          delete newMarkers[key];
          return newMarkers;
        }
      });
    };

    const handleClick = useCallback((ev) => {
        if (!map) return;
        if (!ev.latLng) return;
        console.log('marker clicked:', ev.latLng.toString());
        map.panTo(ev.latLng);
        setCircleCenter(ev.latLng);
      }, [map]);
  
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
        {pois.map((poi) => (
          <AdvancedMarker
            key={poi.key}
            position={poi.location}
            ref={marker => setMarkerRef(marker, poi.key)}
            clickable={true}
            onClick={handleClick}
          >
            <Pin background={'#FBBC04'} glyphColor={'#000'} borderColor={'#000'} />
          </AdvancedMarker>
        ))}
      </>
    );
  };
  

const GoogleMap = ({mapResults}) => {
  console.log("mapResults > 0", mapResults && mapResults.length > 0);
  const pois_ = mapResults && mapResults.length > 0 ? 
    mapResults.map(result => new Poi(result.displayName, result.latLng.latitude, result.latLng.longitude))
    : [];
  console.log("pois_", pois_);

  const [pois, setPois] = useState(pois_);    

  console.log("mapResults", mapResults);
  console.log("pois", pois);

    return (
        <APIProvider apiKey={apiKey} onLoad={() => console.log('Maps API has loaded.')}>
            <Map
                // style={{width: '100vw', height: '100vh'}}
                defaultCenter={{lat: 22.54992, lng: 0}}
                mapId='DEMO_MAP_ID'
                // onCameraChanged={ (ev) =>
                //     console.log('camera changed:', ev.detail.center, 'zoom:', ev.detail.zoom)
                //   }
                defaultZoom={3}
                gestureHandling={'greedy'}
                disableDefaultUI={true}
            >
                <PoiMarkers pois={pois} />
            </Map>
        </APIProvider>
    );
}

export default GoogleMap;