import React, { useEffect, useRef, useContext } from 'react';
import MapDatesResponseBox from './MapDatesResponseBox';
import {AppStateContext} from "../context/AppStateProvider";


const MapDatesResponseBoxesContainer = ({ mapResponseItems, selectedItemId, setSelectedItemId}) => {
    const { selectedDates, selectedMapDateResults } = useContext(AppStateContext);

    const selectedRef = useRef(null);

    // console.log('from MapDatesResponseBoxesContainer', mapResponseItems);

    useEffect(() => {
        if (selectedRef.current) {
            selectedRef.current.scrollIntoView({ behavior: 'smooth' });
        }
    }, [selectedItemId]);




    return (
        <div id='map-results'>
            {selectedDates
                .map((date, index1) => (
                <div key={index1}>
                    <p>{date}</p>
                    {selectedMapDateResults
                        .filter(mapDateResult => mapDateResult.dateType === date)
                        .map((mapDateResult) => (
                        <MapDatesResponseBox
                            key={mapDateResult.displayName}
                            mapResult={mapDateResult}
                            isSelected={selectedItemId === mapDateResult.displayName}
                            onClick={() => setSelectedItemId(mapDateResult.displayName)}
                            ref={selectedItemId === mapDateResult.displayName ? selectedRef : null}
                        />
                    ))}
                </div>
            ))}
        </div>
    );
};

export default MapDatesResponseBoxesContainer;