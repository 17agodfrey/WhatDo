import FilterButton from "../FilterButton";
import Checkbox from '@mui/material/Checkbox';
import FormControlLabel from '@mui/material/FormControlLabel';
import Slider from '@mui/material/Slider';
import { useState } from 'react';
import sortIcon from '../../assets/sort-aqua.svg';
import queryString from 'query-string';
import TextField from '@mui/material/TextField';
import '../../styles/MapSearchPage.css';
import Chip from '@mui/material/Chip';


const MapSearchPage = () => {
    const queryParams = queryString.parse(window.location.search);
    // if location is in query params, set it as the default value
    const [location, setLocation] = useState(queryParams.location ? queryParams.location : ''); 

    const prices = ['$', '$$', '$$$', '$$$$'];
    const [selectedPrices, setSelectedPrices] = useState([]);
    const ratings = ['Any rating', 2, 2.5, 3, 3.5, 4, 4.5, 5];
    const [selectedRatings, setSelectedRatings] = useState([]);
    const indoorOutdoor = ['Indoor', 'Outdoor', 'Any'];
    const [selectedIndoorOutdoor, setSelectedIndoorOutdoor] = useState([]);
    const [duration, setDuration] = useState(null);
    const [radius, setRadius] = useState(null);

    const onPriceChange = (price) => {
        console.log(price);
    }

    const onRatingChange = (rating) => {
        console.log(rating);
    }

    const onIndoorOutdoorChange = (indoorOutdoor) => {
        console.log(indoorOutdoor);
    }





    return (
        <div id='map-search-page-root'>
            <div id='msp-options-section'>
                <TextField 
                    id="outlined-basic" 
                    label={location ? location : "Enter location"} 
                    variant="outlined" 
                    value={location} 
                    onChange={(e) => setLocation(e.target.value)}
                />
                <div className='filters-container'>
                    <FilterButton 
                        label='Price' 
                        variant='list' 
                        possibleValues={prices} 
                        selectedValues={selectedPrices}
                        setSelectedValues={setSelectedPrices}
                    />
                    <FilterButton 
                        label='Rating' 
                        variant='list' 
                        possibleValues={ratings} 
                        selectedValues={selectedRatings}
                        setSelectedValues={setSelectedRatings}
                    />
                    <FilterButton 
                        label='Indoor/Outdoor' 
                        variant='list' 
                        possibleValues={indoorOutdoor} 
                        selectedValues={selectedIndoorOutdoor}
                        setSelectedValues={setSelectedIndoorOutdoor}
                    />
                </div>
                <div className='hz-close'>
                    <p>Sort</p>
                    <img src={sortIcon} alt="" />
                </div>
            </div>
            <div id='msp-main-content'>
                <p>Selected prices: {selectedPrices}</p>
                <p>Selected ratings: {selectedRatings}</p>
                <p>Selected indoor/outdoor: {selectedIndoorOutdoor}</p>
            </div>
        </div>
    );
};

export default MapSearchPage;