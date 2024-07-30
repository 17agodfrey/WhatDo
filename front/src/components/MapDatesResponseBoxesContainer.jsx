import React, { useEffect, useRef } from 'react';
import MapDatesResponseBox from './MapDatesResponseBox';

const MapDatesResponseBoxesContainer = ({ mapResponseItems, selectedItemId }) => {
    const selectedRef = useRef(null);

    useEffect(() => {
        if (selectedRef.current) {
            selectedRef.current.scrollIntoView({ behavior: 'smooth' });
        }
    }, [selectedItemId]);

    return (
        <div id='map-results'>
            {Object.values(mapResponseItems).map((mapResponseItem, index1) => (
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