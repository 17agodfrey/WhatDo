import shrek from '../assets/shrek.jpg';
import PropTypes from 'prop-types';
import React, { forwardRef } from 'react';


const MapDatesResponseBox = forwardRef(({ mapResult, isSelected }, ref) => {
    // console.log(mapResult);
    const image = mapResult.photosUris && mapResult.photosUris.length > 0 ? mapResult.photosUris[0] : shrek;

    return (
        <div ref={ref} className={`map-dates-response-box ${isSelected ? 'highlighted' : ''}`}>
            <img src={image} alt="date image" />
            <div className='date-response-info'>
                <h3>Name: {mapResult.displayName}</h3>
                <p>Description: {mapResult.description}</p>
                <p>Price: {mapResult.priceLevel}</p>
                <p>Rating: {mapResult.rating}</p>
                <p>Location: {mapResult.latLng.latitude}{mapResult.latLng.longitude}</p>
            </div>
        </div>
    );
});

// mapDatesResponseBox.propTypes = {
//     mapResult: PropTypes.shape({
//         displayName: PropTypes.string,
//         description: PropTypes.string,
//         price: PropTypes.number,
//         rating: PropTypes.number,
//         location: PropTypes.string,
//     }).isRequired,
// };

MapDatesResponseBox.displayName = 'AdvancedMarkerElement';


export default MapDatesResponseBox;