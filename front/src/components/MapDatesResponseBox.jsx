import shrek from '../assets/shrek.jpg';
import PropTypes from 'prop-types';
import React, { useState, useRef, useEffect, forwardRef } from 'react';



const MapDatesResponseBox = forwardRef(({ mapResult, isSelected, onBoxClick, onImageClick, color }, ref) => {
    // console.log(mapResult);

    const [showFullName, setShowFullName] = useState(false);
    const [showFullDesc, setShowFullDesc] = useState(false);
    const [showFullLocation, setShowFullLocation] = useState(false); 
    const [isNameTruncated, setIsNameTruncated] = useState(false);
    const [isDescTruncated, setIsDescTruncated] = useState(false);
    const [isLocationTruncated, setIsLocationTruncated] = useState(false);

    const nameRef = useRef(null);
    const descRef = useRef(null);
    const locationRef = useRef(null); 

        // Check if the text is truncated
    useEffect(() => {
        if (nameRef.current) {
            setIsNameTruncated(nameRef.current.scrollHeight > nameRef.current.clientHeight + 1);
        }
        if (descRef.current) {
            setIsDescTruncated(descRef.current.scrollHeight > descRef.current.clientHeight + 1);
        }
        if (locationRef.current) {
            setIsLocationTruncated(locationRef.current.scrollHeight > locationRef.current.clientHeight + 1);
        }
    }, [mapResult.displayName, mapResult.description, showFullName, showFullDesc, showFullLocation]);

    // *** this is currently just getting one image, but you should be using all of them ***
    const photosUris = mapResult.photos.map(photo => photo.photoUri);
    const image = photosUris && photosUris.length > 0 ? photosUris[0] : shrek;

    return (
        <div 
            ref={ref} 
            className={`map-dates-response-box ${isSelected ? 'highlighted' : ''}`}
            style={{borderRight: `6px solid ${color}`}}
            onClick={onBoxClick}
        >
            <div style={{position: 'relative', display: 'inline-block'}}>
                <img 
                    src={image} 
                    alt="date image" 
                    style={{display: "block", cursor: "default"}} 
                />
                <button onClick={e => { e.stopPropagation(); onImageClick(); }} className='more-photos-button'>
                    See More
                </button>
            </div>
            
            <div className='date-response-info body-text'>
            <h3
                ref={nameRef}
                className={!showFullName ? 'clamp-2' : ''}
                style={{marginBottom: 0}}
            >
                Name: {mapResult.displayName}
                {!showFullName && isNameTruncated && (
                    <span
                        style={{color:'#888', marginLeft:4, cursor:'pointer'}}
                        title="Click to expand"
                        onClick={e => { e.stopPropagation(); setShowFullName(true); }}
                    >…</span>
                )}
                {showFullName && isNameTruncated && (
                    <span
                        style={{color:'#888', marginLeft:4, cursor:'pointer'}}
                        title="Click to collapse"
                        onClick={e => { e.stopPropagation(); setShowFullName(false); }}
                    >▲</span>
                )}
            </h3>
            <p
                ref={descRef}
                className={!showFullDesc ? 'clamp-5' : ''}
            >
                Description: {mapResult.description}
                {!showFullDesc && isDescTruncated && (
                    <span
                        style={{color:'#888', marginLeft:4, cursor:'pointer'}}
                        title="Click to expand"
                        onClick={e => { e.stopPropagation(); setShowFullDesc(true); }}
                    >…</span>
                )}
                {showFullDesc && isDescTruncated && (
                    <span
                        style={{color:'#888', marginLeft:4, cursor:'pointer'}}
                        title="Click to collapse"
                        onClick={e => { e.stopPropagation(); setShowFullDesc(false); }}
                    >▲</span>
                )}
            </p>
            <p>Price: {mapResult.priceLevel}</p>
            <p>Rating: {mapResult.rating}</p>
            <p
                ref={locationRef}
                className={!showFullLocation ? 'clamp-1' : ''}
            >
                Location: {mapResult.latLng.latitude}{mapResult.latLng.longitude}
                {!showFullLocation && isLocationTruncated && (
                    <span
                        style={{color:'#888', marginLeft:4, cursor:'pointer'}}
                        title="Click to expand"
                        onClick={e => { e.stopPropagation(); setShowFullLocation(true); }}
                    >…</span>
                )}
                {showFullLocation && isLocationTruncated && (
                    <span
                        style={{color:'#888', marginLeft:4, cursor:'pointer'}}
                        title="Click to collapse"
                        onClick={e => { e.stopPropagation(); setShowFullLocation(false); }}
                    >▲</span>
                )}
            </p>
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