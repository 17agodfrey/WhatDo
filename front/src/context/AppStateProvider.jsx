import { useState, createContext, useEffect } from 'react';

// Create a context to hold the state
export const AppStateContext = createContext();


// *** remember whenever you add another state variable you need to 
// *** add it to the AppStateProvider function and the AppStateContext.Provider value
const AppStateProvider = ({ children }) => {
  const indoorOutdoor = ['Indoor', 'Outdoor', 'Any'];
  const duration = [1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5];
  const activityLevels = ["Low", "Medium", "High"];
  const prices = ['$', '$$', '$$$', '$$$$'];
  const ratings = [2, 2.5, 3, 3.5, 4, 4.5, 5];
  

  const [location, setLocation] = useState(localStorage.getItem('location') || '');
  const [selectedIndoorOutdoor, setSelectedIndoorOutdoor] = useState(JSON.parse(localStorage.getItem('selectedIndoorOutdoor')) || 'Any');
  const [selectedDuration, setSelectedDuration] = useState(JSON.parse(localStorage.getItem('selectedDuration')) || [1, 5]);
  const [selectedActivityLevels, setSelectedActivityLevels] = useState(JSON.parse(localStorage.getItem('selectedActivityLevels')) || []);
  const [selectedPrices, setSelectedPrices] = useState(JSON.parse(localStorage.getItem('selectedPrices')) || []);
  const [selectedRating, setSelectedRating] = useState(JSON.parse(localStorage.getItem('selectedRating')) || []);

  // this is a dict vvvv 
  const [mapResponseItems, setMapResponseItems] = useState(JSON.parse(localStorage.getItem('mapResponseItems')) || []);
  const [isLoading, setIsLoading] = useState(false);

  const [selectedDates, setSelectedDates] = useState(JSON.parse(localStorage.getItem('selectedDates')) || []);

  // Save state variables to localStorage whenever they change
  useEffect(() => {
    localStorage.setItem('location', location);
  }, [location]);

  useEffect(() => {
    localStorage.setItem('selectedIndoorOutdoor', JSON.stringify(selectedIndoorOutdoor));
  }, [selectedIndoorOutdoor]);

  useEffect(() => {
    localStorage.setItem('selectedDuration', JSON.stringify(selectedDuration));
  }, [selectedDuration]);

  useEffect(() => {
    localStorage.setItem('selectedActivityLevels', JSON.stringify(selectedActivityLevels));
  }, [selectedActivityLevels]);

  useEffect(() => {
    localStorage.setItem('selectedPrices', JSON.stringify(selectedPrices));
  }, [selectedPrices]);

  useEffect(() => {
    localStorage.setItem('selectedRating', JSON.stringify(selectedRating));
  }, [selectedRating]);

  useEffect(() => {
    localStorage.setItem('mapResponseItems', JSON.stringify(mapResponseItems));
    // if (Object.keys(mapResponseItems).length > 0) {
    //     setLoading(false);
    // }
}, [mapResponseItems]);

  useEffect(() => {
    localStorage.setItem('selectedDates', JSON.stringify(selectedDates));
  }, [selectedDates]);

  return (
    <AppStateContext.Provider
      value={{
        location,
        setLocation,
        indoorOutdoor,
        selectedIndoorOutdoor,
        setSelectedIndoorOutdoor,
        duration,
        selectedDuration,
        setSelectedDuration,
        activityLevels,
        selectedActivityLevels,
        setSelectedActivityLevels,
        prices,
        selectedPrices,
        setSelectedPrices,
        ratings, 
        selectedRating,
        setSelectedRating,
        mapResponseItems,
        setMapResponseItems,
        isLoading,
        setIsLoading, 
        selectedDates,
        setSelectedDates,
      }}
    >
      {children}
    </AppStateContext.Provider>
  );
};

export default AppStateProvider;