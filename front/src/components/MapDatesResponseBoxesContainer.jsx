import React, { useEffect, useRef, useContext } from 'react';
import MapDatesResponseBox from './MapDatesResponseBox';
import {AppStateContext} from "../context/AppStateProvider";

const colors = ['#D72638', '#3F88C5', '#F49D37', '#9842f5', '#1aba1a'];

const MapDatesResponseBoxesContainer = ({ mapResponseItems, selectedItemId, setSelectedItemId, setImageGalleryOpen}) => {
    const { selectedDates, selectedMapDateResults } = useContext(AppStateContext);
    const selectedRef = useRef(null);

    // console.log('from MapDatesResponseBoxesContainer', mapResponseItems);

    useEffect(() => {
        if (selectedRef.current) {
            selectedRef.current.scrollIntoView({ behavior: 'smooth' });
        }
    }, [selectedItemId]);

    //function to captilize word: 
    const capitalizeFirstLetter = (string) => {
        return string.charAt(0).toUpperCase() + string.slice(1);
    };



    return (
    <div id='map-results'>
        {selectedDates.map((date, index1) => {
            // Find the index of the date in mapResponseItems
            const mapResponseItemsArray = Object.values(mapResponseItems);
            const colorIndex = mapResponseItemsArray.findIndex(item => item.date.name === date);

            return (
                <div key={index1}>
                    <p className='date-header'>{capitalizeFirstLetter(date)}</p>
                    {selectedMapDateResults
                        .filter(mapDateResult => mapDateResult.dateType === date)
                        .map((mapDateResult) => (
                            <MapDatesResponseBox
                                key={mapDateResult.displayName}
                                mapResult={mapDateResult}
                                isSelected={selectedItemId === mapDateResult.displayName}
                                onBoxClick={() => setSelectedItemId(mapDateResult.displayName)}
                                onImageClick={() => { setImageGalleryOpen(true); }}
                                color={colors[colorIndex % colors.length]} // use consistent color
                                ref={selectedItemId === mapDateResult.displayName ? selectedRef : null}
                            />
                        ))}
                </div>
            );
        })}
    </div>
    );
};

export default MapDatesResponseBoxesContainer;