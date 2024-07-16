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
import GoogleMap from '../GoogleMap';
import responseItem from '../../models/MapDatesResponse';
import { useApiWithoutToken } from "../../hooks";
import MapDatesResponseBox from '../MapDatesResponseBox';


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
    const [selectedDuration, setSelectedDuration] = useState([1,5]);
    const duration = [1,5];
    const [selectedRadius, setSelectedRadius] = useState(15);
    const radius = [5,25];

    const api = useApiWithoutToken();
    const [mapResponseItems, setMapResponseItems] = useState(Array(4).fill(responseItem));

    const handleSubmit = () => {
        const query = {
            location: location,
            prices: selectedPrices,
            ratings: selectedRatings,
            indoorOutdoor: selectedIndoorOutdoor,
            duration: selectedDuration,
            radius: selectedRadius
        }
        console.log(query);
        api.get('/date', query)
            .then(res => {
                console.log(res);
                setMapResponseItems(res.data);
            })
            .catch(err => {
                console.log(err);
            })
    }




    return (
        <div id='map-search-page-root'>
            <div id='msp-options-section-flex'>
                <div id='msp-options-section'>
                    <TextField 
                        id="outlined-basic" 
                        label={location ? location : "Enter location"} 
                        variant="outlined" 
                        value={location} 
                        onChange={(e) => setLocation(e.target.value)}
                        InputLabelProps={{shrink: false}}
                        size="small"
                        sx={{minWidth: 'fit-content'}}
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
                        <FilterButton 
                            label='Duration' 
                            variant='slider' 
                            possibleValues={duration}
                            selectedValues={selectedDuration} 
                            setSelectedValues={setSelectedDuration}
                        />
                        {/* <FilterButton 
                            label='Radius' 
                            variant='slider'  
                            possibleValues={radius}
                            selectedValues={selectedRadius} 
                            setSelectedValues={setSelectedRadius}
                        /> */}
                        <button id='msp-search-button' onClick={() => handleSubmit()}>
                            Search
                        </button>
                    </div>
                    <div className='hz-close'>
                        <p>Sort</p>
                        <img src={sortIcon} alt="" />
                    </div>
                </div>
            </div>
            <div id='msp-main-content'>
                <div id='map'>
                    <GoogleMap/>
                </div>
                <div id='map-results'>
                    {mapResponseItems.map((mapResponseItem, index1) => (
                        <div key={index1}>
                            <p>{mapResponseItem.date.name}</p>
                            {mapResponseItem.results.map((mapResult, index2) => (
                                <MapDatesResponseBox key={index2} mapResult={mapResult} />
                            ))}
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
};

export default MapSearchPage;