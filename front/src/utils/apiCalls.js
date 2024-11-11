import {AppStateContext} from "../context/AppStateProvider";
import {useContext} from 'react'
import {FindMapDatesResponseItem, FindMapDatesResult, Date} from '../models/MapDatesResponse';
import queryString from 'query-string';




const mapSearch = async (
    api,
    selectedDates,
    location, 
) => {

    // const queryParams = {
    //     'DurationRange.Min': selectedDuration.length > 0 ? selectedDuration[0] : undefined,
    //     'DurationRange.Max': selectedDuration.length > 1 ? selectedDuration[1] : undefined,
    //     'PriceLevels': selectedPrices.length > 0 ? selectedPrices : undefined,
    //     'Rating': selectedRating.length > 0 ? selectedRating : undefined,
    //     'ActivityLevels': selectedActivityLevels.length > 0 ? selectedActivityLevels : undefined,
    //     'IndoorOutdoor': selectedIndoorOutdoor.length > 0 ? selectedIndoorOutdoor : undefined,
    //     'Location': location,
    // }

    const dateIds = selectedDates.map(date => date.id);

    const queryParams = {
        'DateIds': dateIds,
        'Location': location,
    }

    // Remove undefined values
    const filteredQueryParams = Object.fromEntries(
        Object.entries(queryParams).filter(([key, value]) => value !== undefined)
    );

    // stringify is needed because get requests don't have a body. so everything is passed 
    // to the url
    const queryStringified = queryString.stringify(filteredQueryParams);
    console.log('from apiCalls, requestParams: ', filteredQueryParams);

    try {
        const response = await api.get(`date/map-dates?${queryStringified}`)
        if(response.ok){
            const data = await response.json();
            console.log("api called");
            console.log(data);
            // const mapResultsReturned = [];
            const responseItemsDict = {};
            data.map(item => {
                const date = new Date(
                    item.date.id, 
                    item.date.name, 
                    item.date.duration, 
                    item.date.activityLevel, 
                    item.date.indoorOutdoor
                );
                const results = item.results.map(result => {
                    return new FindMapDatesResult(
                        result.googleMapsId,
                        result.displayName,
                        result.latLng, 
                        result.description, 
                        result.priceLevel,
                        result.rating, 
                        result.photos,
                        // result.photosUris,
                        result.dateType
                    );
                });
                // mapResultsReturned.push(...results);
                responseItemsDict[date.name] = new FindMapDatesResponseItem(date, results);
            });
            // setMapResults(mapResultsReturned);
            // setMapResponseItems(responseItems);
            // setMapResponseItems(responseItemsDict);
            // setIsLoading(false);
            // setMapResponseItems(responseItemsDict);
            return responseItemsDict;
        }

    } catch (error){
        console.log(error);
        // setIsLoading(false);
    }
}

const dateIdeasSearch = async (
    api,
    selectedIndoorOutdoor, 
    selectedDuration, 
    selectedActivityLevels, 
    // setIsLoading,
) => {

    // setIsLoading(true);

    const queryParams = {
        'IndoorOutdoor': selectedIndoorOutdoor,
        'DurationRange.Min': selectedDuration[0],
        'DurationRange.Max': selectedDuration[1],
        'ActivityLevels': selectedActivityLevels,
    }

    // make sure the values are not undefined throw error if they are
    Object.values(queryParams).forEach(value => {
        if(value === undefined){
            throw new Error(`${value} is undefined`);
        }
    });

    // stringify is needed because get requests don't have a body. so everything is passed 
    // to the url
    const queryStringified = queryString.stringify(queryParams);
    console.log('from apiCalls, requestParams: ', queryParams);

    try {
        const response = await api.get(`date/date-ideas?${queryStringified}`)
        if (response.ok) {
            const data = await response.json();
            console.log("api called");
            console.log(data);
            return data;
        } else {
            // Handle non-OK responses
            throw new Error('Error fetching date ideas');
        }

    } catch (error){
        // setIsLoading(false);
        console.log(error);
    }
}

export { mapSearch, dateIdeasSearch };