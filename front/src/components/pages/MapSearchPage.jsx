import FilterButton from "../FilterButton";
import Checkbox from '@mui/material/Checkbox';
import FormControlLabel from '@mui/material/FormControlLabel';
import Slider from '@mui/material/Slider';
import Button from '@mui/material/Button';
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
import { mapSearch, dateIdeasSearch } from "../../utils/apiCalls";
import DialogButton from "../DialogButton";
import CriteriaBox from "../CriteriaBox";
import MapResultImageGalleryDialog from "../MapResultImageGalleryDialog";




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
        selectedDates, setSelectedDates,
        mapDateResults, 
        selectedMapDateResults, setSelectedMapDateResults,
        mapResponseDateObjects, setMapResponseDateObjects,
        setMapDateResults,
    } = useContext(AppStateContext);

    // const [isLoading, setLoading] = useState(false); // Loading state
    // const queryParams = queryString.parse(window.location.search);


    const api = useApiWithoutToken();
    // const [mapResponseItems, setMapResponseItems] = useState(JSON.parse(localStorage.getItem('mapResponseItems')) || []);
    // const [mapResults, setMapResults] = useState(JSON.parse(localStorage.getItem('mapResults')) || []);
    // console.log("mapResults: ", mapResults);

    const [selectedItemId, setSelectedItemId] = useState(null);
    const [showNewDateResults, setShowNewDateResults] = useState(false);
    const [newDateIdeas, setNewDateIdeas] = useState([]);
    const [newDateIdeasSelected, setNewDateIdeasSelected] = useState([]);
    const [newSearchDialogOpen, setNewSearchDialogOpen] = useState(false);  
    const [imageGalleryOpen, setImageGalleryOpen] = useState(false);

    useEffect(() => {
        console.log('selectedItemId: ', selectedItemId);
    }, [selectedItemId]);
    // const [showMapResults, setShowMapResults] = useState(false);

    // const handleSwitchChange = (event) => {
    //     setShowMapResults(event.target.checked);
    // };

    // useEffect(() => {
    //     // localStorage.setItem('mapResponseItems', JSON.stringify(mapResponseItems));
    //     if (Object.keys(mapResponseItems).length > 0) {
    //         setIsLoading(false);
    //     }
    // }, [setIsLoading, mapResponseItems]);

    // useEffect(() => {
    //     // let dateIdea;
    //     // let currDateIdeaName = '';
    //     // for(const selectedMapDateResult of selectedMapDateResults) {
    //     //     if(selectedMapDateResult.dateType !== currDateIdeaName) {
    //     //         currDateIdeaName = selectedMapDateResult.dateType;
    //     //         dateIdea = mapResponseDateObjects[selectedMapDateResult.dateType];
    //     //     }
    //     //     if(selectedDates.includes(selectedMapDateResult.date) &&
    //     //         selectedMapDateResult) {
    //     //         console.log('selectedMapDateResult: ', selectedMapDateResult);
    //     //     }
    //     // }

    //     const newSelectedDates = [];
    //     for(const mapResponseDateObject of Object.values(mapResponseDateObjects)){
    //         if(selectedDates.includes(mapResponseDateObject.name) &&
    //             (mapResponseDateObject.indoorOutdoor === selectedIndoorOutdoor || selectedIndoorOutdoor === 'Any')) {
    //             newSelectedDates.push(mapResponseDateObject.name);
    //         }
    //     }

    //     setSelectedDates(newSelectedDates);
    // }, [selectedIndoorOutdoor]);

    // useEffect(() => {
    //     const newSelectedDates = [];
    //     for(const mapResponseDateObject of Object.values(mapResponseDateObjects)){
    //         if(selectedDates.includes(mapResponseDateObject.name) &&
    //             (mapResponseDateObject.duration >= selectedDuration[0] && mapResponseDateObject.duration <= selectedDuration[1])) {
    //             newSelectedDates.push(mapResponseDateObject.name);
    //         }
    //     }

    //     setSelectedDates(newSelectedDates);
    // }, [selectedDuration]);

    // useEffect(() => {
    //     const newSelectedDates = [];
    //     for(const mapResponseDateObject of Object.values(mapResponseDateObjects)){
    //         if(selectedDates.includes(mapResponseDateObject.name) &&
    //             (selectedActivityLevels.includes(mapResponseDateObject.activityLevel))) {
    //             newSelectedDates.push(mapResponseDateObject.name);
    //         }
    //     }

    //     setSelectedDates(newSelectedDates);
    // }, [selectedActivityLevels]);

    useEffect(() => {
        console.log('selectedPrices: ', selectedPrices);
        if(selectedPrices.length > 0) {
            let newSelectedMapDateResults = [];
            for(const mapDateResult of mapDateResults) {
                if(selectedDates.includes(mapDateResult.dateType) &&
                selectedPrices.includes(mapDateResult.price)) {
                    newSelectedMapDateResults.push(mapDateResult);
                    console.log('selectedMapDateResult: ', mapDateResult);
                }
            }
    
            setSelectedMapDateResults(newSelectedMapDateResults);
        }
    }, [selectedPrices]);

    useEffect(() => {
        console.log('selectedRating: ', selectedRating);
        if(selectedRating.length > 0) {
            let newSelectedMapDateResults = [];
            for(const mapDateResult of mapDateResults) {
                if(selectedDates.includes(mapDateResult.dateType) &&
                mapDateResult.rating >= selectedRating) {
                    newSelectedMapDateResults.push(mapDateResult);
                    console.log('selectedMapDateResult: ', mapDateResult);
                }
            }
    
            setSelectedMapDateResults(newSelectedMapDateResults);
        }
    }, [selectedRating]);

    const newDateSearch = async () => {
        setIsLoading(true);
        const response = await dateIdeasSearch(
            api,
            selectedIndoorOutdoor,
            selectedDuration,
            selectedActivityLevels,
        );
        setNewDateIdeasSelected([]);
        setNewDateIdeas(response);
        setIsLoading(false);
        setShowNewDateResults(true);
    }

    const newMapSearch = async () => {
        setIsLoading(true);
        setSelectedDates(newDateIdeasSelected);
        const selectedDateObjects = newDateIdeas.filter((date) => newDateIdeasSelected.includes(date.name));  
        const response = await mapSearch(
            api,
            selectedDateObjects,
            location,
        );
        setMapResponseItems(response);
        const results = Object.values(response).map(responseItem => responseItem.results).flat();
        setSelectedMapDateResults(results);
        setMapDateResults(results);
        let tempMapResponseDateObjects = {};
        for(const newDateIdea of newDateIdeas) {
            if(selectedDates.includes(newDateIdea.name)) {
                tempMapResponseDateObjects[newDateIdea.name] = newDateIdea;
            }
        }
        setMapResponseDateObjects(tempMapResponseDateObjects);
        setIsLoading(false);
        //close dialog somehow 
        setNewSearchDialogOpen(false);
    }
        

    const handleDatesSelectedChange = (event) => {
        const date = event.target.value;
        if (selectedDates.includes(date)) {
            setSelectedDates(selectedDates.filter((selectedDate) => selectedDate !== date));
        } else {
            setSelectedDates([...selectedDates, date]);
        }
        //re-render
    }

    const handleNewDateIdeaSelectedChange = (event) => {
        const date = event.target.value;
        if(newDateIdeasSelected.includes(date)) {
            setNewDateIdeasSelected(newDateIdeasSelected.filter((newDateIdea) => newDateIdea !== date));
        } else {
            setNewDateIdeasSelected([...newDateIdeasSelected, date]);
        }
    }

    const handleDialogSeeDatesButtonClicked = () => {
        newDateSearch();
    }

    const handleNewSearchDialogClose = () => {
        setShowNewDateResults(false);
        setNewDateIdeas([]);
    }

    const handleConfirmNewDatesButtonClicked = () => {
        newMapSearch();
    }

    const handleNewDatesCancelButton = () => {
        setNewSearchDialogOpen(false);
    }

    return (
        <div id='map-search-page-root'>
            <div id='msp-options-section-flex'>
                <div id='msp-options-section'>

                    <DialogButton 
                        id='msp-search-button'
                        text='New Search'
                        onClose={handleNewSearchDialogClose}
                        isOpen={newSearchDialogOpen}
                        setIsOpen={setNewSearchDialogOpen}
                        content={
                            <>
                                {!isLoading && !showNewDateResults &&
                                    <>
                                        <CriteriaBox/>
                                        <div id='msp-new-search-dialog-bottom-section' className='hz-center'>
                                            <TextField 
                                                label={location ? location : "Enter location"} 
                                                variant="outlined" 
                                                value={location} 
                                                onChange={(e) => setLocation(e.target.value)}
                                                // InputLabelProps={{shrink: false}}
                                                size="small"
                                                sx={{minWidth: 'fit-content'}}
                                            />
                                            <Button 
                                                variant="contained" 
                                                style={{ backgroundColor: '#A1D7F5', color: 'white' }} 
                                                onClick={handleDialogSeeDatesButtonClicked}
                                            >See dates
                                            </Button>                                    
                                        </div>
                                    </>
                                }
                                {isLoading &&
                                    <>
                                        <img src={ThanosDance} alt="loading symbol" />
                                    </>
                                }
                                {!isLoading && showNewDateResults &&
                                    <>
                                        {       
                                            mapResponseItems && 
                                            <>
                                                <div id='msp-dates-selected-dialog-content' className='v-center'>
                                                    <div className="y-scroll">
                                                        {newDateIdeas.map((newDateIdea, index1) => (
                                                            <FormControlLabel
                                                                key={newDateIdea.name}
                                                                value={newDateIdea.name}
                                                                control={
                                                                    <Checkbox
                                                                        checked={newDateIdeasSelected.includes(newDateIdea.name)}
                                                                        onChange={handleNewDateIdeaSelectedChange}
                                                                        value={newDateIdea.name}
                                                                    />
                                                                }                        
                                                                label={newDateIdea.name}
                                                            />
                                                        ))}
                                                    </div>
                                                </div>
                                                <div id='msp-new-search-dialog-new-dates-bottom-section'className='hz-center'>
                                                    <Button 
                                                        variant="contained" 
                                                        style={{ backgroundColor: '#F69EA3', color: 'white' }} 
                                                        onClick={handleNewDatesCancelButton}>Cancel
                                                    </Button> 
                                                    <Button 
                                                        variant="contained" 
                                                        style={{ backgroundColor: '#A1D7F5', color: 'white' }} 
                                                        onClick={handleConfirmNewDatesButtonClicked}>Confirm New Dates
                                                    </Button>    
                                                </div>
                                        
                                            </> 
                                        }                                        
                                    </>
                                }
                            </>
                        }
                    >
                    </DialogButton>
                    <div className='filters-container'>
                        {/* <FilterButton 
                            label='Setting' 
                            variant='radio' 
                            possibleValues={indoorOutdoor} 
                            selectedValues={selectedIndoorOutdoor}
                            setSelectedValues={setSelectedIndoorOutdoor}
                        /> */}
                        {/* <FilterButton 
                            label='Duration' 
                            variant='slider' 
                            possibleValues={duration}
                            selectedValues={selectedDuration} 
                            setSelectedValues={setSelectedDuration}
                        />               */}
                        {/* <FilterButton 
                            label='Activity Level' 
                            variant='list' 
                            possibleValues={activityLevels}
                            selectedValues={selectedActivityLevels} 
                            setSelectedValues={setSelectedActivityLevels}
                        />                                  */}
                        <FilterButton 
                            label='Price' 
                            variant='list' 
                            possibleValues={prices} 
                            selectedValues={selectedPrices}
                            setSelectedValues={setSelectedPrices}
                        />
                        <FilterButton 
                            label='Rating' 
                            variant='radio' 
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
                            title='Date Types Selected'
                            content={
                                mapResponseItems && 
                                <div id='msp-dates-selected-dialog-content' className='v-center'>
                                    <div className='y-scroll'>
                                        {Object.values(mapResponseItems).map((mapResponseItem, index1) => (
                                            <FormControlLabel
                                                key={mapResponseItem.date.name}
                                                value={mapResponseItem.date.name}
                                                control={
                                                    <Checkbox
                                                        checked={selectedDates.includes(mapResponseItem.date.name)}
                                                        onChange={handleDatesSelectedChange}
                                                        value={mapResponseItem.date.name}
                                                    />
                                                }                        
                                                label={mapResponseItem.date.name}
                                            />
                                        ))}
                                    </div>
                                </div>
                                }
                        />
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
                            selectedItemId={selectedItemId}
                            setSelectedItemId={setSelectedItemId}
                        />
                    </div>
                    <MapDatesResponseBoxesContainer 
                        mapResponseItems={mapResponseItems}
                        selectedItemId={selectedItemId}
                        setSelectedItemId={setSelectedItemId}
                        // showMapResults={showMapResults}
                        setImageGalleryOpen={setImageGalleryOpen}
                    />
                </>
                }
            </div>
            <MapResultImageGalleryDialog
                open={imageGalleryOpen}
                onClose={() => setImageGalleryOpen(false)}
                imageUrls={() => selectedMapDateResults.filter(mapDateResult => mapDateResult.displayName === selectedItemId)[0].photos.map(photo => photo.photoUri)}
            />
        </div>
    );
};

export default MapSearchPage;