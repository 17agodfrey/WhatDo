import React, { useEffect, useRef, useContext } from 'react';
import MapDatesResponseBox from './MapDatesResponseBox';
import {AppStateContext} from "../context/AppStateProvider";


const MapDatesResponseBoxesContainer = ({ mapResponseItems, selectedItemId}) => {
    const { selectedDates } = useContext(AppStateContext);

    const selectedRef = useRef(null);

    console.log('from MapDatesResponseBoxesContainer', mapResponseItems);

    useEffect(() => {
        if (selectedRef.current) {
            selectedRef.current.scrollIntoView({ behavior: 'smooth' });
        }
    }, [selectedItemId]);

    return (
        <div id='map-results'>
            {Object.values(mapResponseItems)
                .filter(mapResponseItem => selectedDates.includes(mapResponseItem.date.name))
                .map((mapResponseItem, index1) => (
                <div key={index1}>
                    <p>{mapResponseItem.date.name}</p>
                    {mapResponseItem.results.map((mapResult, index2) => (
                        <MapDatesResponseBox
                            key={index2}
                            mapResult={mapResult}
                            isSelected={selectedItemId === mapResult.displayName}
                            ref={selectedItemId === mapResult.displayName ? selectedRef : null}
                        />
                    ))}
                </div>
            ))}
        </div>
    );
};

export default MapDatesResponseBoxesContainer;