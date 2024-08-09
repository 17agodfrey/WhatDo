import FilterButton from "../FilterButton";
import Checkbox from '@mui/material/Checkbox';
import FormControlLabel from '@mui/material/FormControlLabel';
import Slider from '@mui/material/Slider';
import { useState, useEffect, useContext } from 'react';
import sortIcon from '../../assets/sort-aqua.svg';
import queryString from 'query-string';
import TextField from '@mui/material/TextField';
import '../../styles/MapSearchPage.css';
import Chip from '@mui/material/Chip';
import GoogleMap from '../GoogleMaps/GoogleMap';
import {FindMapDatesResponseItem, FindMapDatesResult, Date} from '../../models/MapDatesResponse';
import { useApiWithoutToken } from "../../hooks";
// import MapDatesResponseBox from '../MapDatesResponseBox';
import MapDatesResponseBoxesContainer from '../MapDatesResponseBoxesContainer';
import ThanosDance from '../../assets/thanos-dance.gif';
import {AppStateContext} from "../../context/AppStateProvider";
import { mapSearch } from "../../utils/apiCalls";
import DialogButton from "../DialogButton";




const MapSearchPage = () => {
    const { 
        location, setLocation, 
        indoorOutdoor, selectedIndoorOutdoor, setSelectedIndoorOutdoor, 
        duration, selectedDuration, setSelectedDuration, 
        activityLevels, selectedActivityLevels, setSelectedActivityLevels, 
        prices, selectedPrices, setSelectedPrices, 
        ratings, selectedRating, setSelectedRating, 
        mapResponseItems, setMapResponseItems, 
        isLoading, setIsLoading,
    } = useContext(AppStateContext);

    // const [isLoading, setLoading] = useState(false); // Loading state
    // const queryParams = queryString.parse(window.location.search);


    const api = useApiWithoutToken();
    // const [mapResponseItems, setMapResponseItems] = useState(JSON.parse(localStorage.getItem('mapResponseItems')) || []);
    // const [mapResults, setMapResults] = useState(JSON.parse(localStorage.getItem('mapResults')) || []);
    // console.log("mapResults: ", mapResults);

    const [selectedItemId, setSelectedItemId] = useState(null);
    // const [showMapResults, setShowMapResults] = useState(false);

    // const handleSwitchChange = (event) => {
    //     setShowMapResults(event.target.checked);
    // };



    useEffect(() => {
        // localStorage.setItem('mapResponseItems', JSON.stringify(mapResponseItems));
        if (Object.keys(mapResponseItems).length > 0) {
            setIsLoading(false);
        }
    }, [setIsLoading, mapResponseItems]);

    // useEffect(() => {
    //     localStorage.setItem('mapResults', JSON.stringify(mapResults));
    // }, [mapResults]);

    // const handleSubmit = async () => {
    //     setLoading(true);

    //     const queryParams = {
    //         'DurationRange.Min': selectedDuration.length > 0 ? selectedDuration[0] : undefined,
    //         'DurationRange.Max': selectedDuration.length > 1 ? selectedDuration[1] : undefined,
    //         'PriceLevels': selectedPrices.length > 0 ? selectedPrices : undefined,
    //         'Rating': selectedRating.length > 0 ? selectedRating : undefined,
    //         'ActivityLevels': selectedActivityLevels.length > 0 ? selectedActivityLevels : undefined,
    //         'IndoorOutdoor': selectedIndoorOutdoor.length > 0 ? selectedIndoorOutdoor : undefined,
    //         'Location': location,
    //     }

    //     // Remove undefined values
    //     const filteredQueryParams = Object.fromEntries(
    //         Object.entries(queryParams).filter(([key, value]) => value !== undefined)
    //     );

    //     const queryStringified = queryString.stringify(filteredQueryParams);
    //     // console.log(filteredQueryParams);

    //     try {
    //         const response = await api.get(`/date?${queryStringified}`)
    //         if(response.ok){
    //             response.json().then(data => {
    //                 console.log("api called");
    //                 console.log(data);
    //                 // const mapResultsReturned = [];
    //                 const responseItemsDict = {};
    //                 data.map(item => {
    //                     const date = new Date(
    //                         item.date.id, 
    //                         item.date.name, 
    //                         item.date.duration, 
    //                         item.date.activityLevel, 
    //                         item.date.indoorOutdoor
    //                     );
    //                     const results = item.results.map(result => {
    //                         return new FindMapDatesResult(
    //                             result.googleMapsId,
    //                             result.displayName,
    //                             result.latLng, 
    //                             result.description, 
    //                             result.priceLevel,
    //                             result.rating, 
    //                             "remove this:: photos ", 
    //                             result.photosUris
    //                         );
    //                     });
    //                     // mapResultsReturned.push(...results);
    //                     responseItemsDict[date.name] = new FindMapDatesResponseItem(date, results);
    //                 });
    //                 // setMapResults(mapResultsReturned);
    //                 // setMapResponseItems(responseItems);
    //                 setMapResponseItems(responseItemsDict);
    //                 setLoading(false);
    //             });
    //         }

    //     } catch (error){
    //         console.log(error);
    //     }
    // }

    const handleSubmit = async () => {
        setIsLoading(true);
        const response = await mapSearch(
            selectedDuration, 
            selectedPrices,
            selectedRating,
            selectedActivityLevels,
            selectedIndoorOutdoor,
            location, 
            api
        );
        setMapResponseItems(response);
        setIsLoading(false);
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
                            label='Setting' 
                            variant='radio' 
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
                        <FilterButton 
                            label='Activity Level' 
                            variant='list' 
                            possibleValues={activityLevels}
                            selectedValues={selectedActivityLevels} 
                            setSelectedValues={setSelectedActivityLevels}
                        />                                 
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
                            selectedValues={selectedRating}
                            setSelectedValues={setSelectedRating}
                        />
                        {/* <FilterButton 
                            label='Radius' 
                            variant='slider'  
                            possibleValues={radius}
                            selectedValues={selectedRadius} 
                            setSelectedValues={setSelectedRadius}
                        /> */}
                        <DialogButton
                            text='Dates Selected'
                        />
                        <button id='msp-search-button' onClick={handleSubmit}>
                            Search
                        </button>
                    </div>
                    <div className='hz-close'>
                        {/* <FormControlLabel control={
                            <Switch
                                checked={showMapResults}
                                onChange={handleSwitchChange}
                                inputProps={{ 'aria-label': 'controlled' }}
                            />} 
                            label={showMapResults ? 'Map Results' : 'Date Types'} 
                            labelPlacement='start'
                        /> */}
                        <p id='sort-text'>Sort</p>
                        <img src={sortIcon} alt="" />
                    </div>
                </div>
            </div>
            <div className={`msp-main-content ${isLoading ? 'loading' : ''}`}>
                {isLoading && 
                    <img id='load-img' src={ThanosDance} alt="" />
                }
                
                {!isLoading &&
                <>
                    <div id='map'>
                        <GoogleMap 
                            mapResponseItems={mapResponseItems}
                            setSelectedItemId={setSelectedItemId}
                        />
                    </div>
                    <MapDatesResponseBoxesContainer 
                        mapResponseItems={mapResponseItems}
                        selectedItemId={selectedItemId}
                        // showMapResults={showMapResults}
                    />
                </>
                }
            </div>
        </div>
    );
};

export default MapSearchPage;