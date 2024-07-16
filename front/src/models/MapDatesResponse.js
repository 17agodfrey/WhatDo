// Date class
class Date {
    constructor(id, name, description = null, duration = null, price = null, rating = null, activityLevel = null, indoorOutdoor = null) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.duration = duration;
        this.price = price;
        this.rating = rating;
        this.activityLevel = activityLevel;
        this.indoorOutdoor = indoorOutdoor;
    }
}

// FindMapDatesResult class
class FindMapDatesResult {
    constructor(googleMapsId, displayName, location, description = null, price = null, rating = null, photos = null) {
        this.googleMapsId = googleMapsId;
        this.displayName = displayName;
        this.location = location;
        this.description = description;
        this.price = price;
        this.rating = rating;
        this.photos = photos;
    }
}

// FindMapDatesResponseItem class - contains a Date and an array of FindMapDatesResult
class FindMapDatesResponse {
    constructor(date, results = []) {
        if (!(date instanceof Date)) {
            throw new Error("date must be an instance of Date");
        }
        this.date = date;
        this.results = results.map(result => {
            if (!(result instanceof FindMapDatesResult)) {
                throw new Error("Each result must be an instance of FindMapDatesResult");
            }
            return result;
        });
    }
}

// Example usage
const date = new Date(
    '123e4567-e89b-12d3-a456-426614174000', 
    'Date Name', 
    'Description', 
    2.5, 
    'Free', 
    '5 stars', 
    'Medium', 
    'Indoor'
);

const result1 = new FindMapDatesResult(
    'ChIJN1t_tDeuEmsRUsoyG83frY4', 
    'Place 1', 
    'Description 1', 
    '$10', 
    '4.5 stars'
);

const result2 = new FindMapDatesResult(
    'ChIJN1t_tDeuEmsRUsoyG83frY5', 
    'Place 2', 
    'Description 2', 
    '$15', 
    '4.7 stars'
);

const responseItem = new FindMapDatesResponse(date, [result1, result2]);

// console.log(responseItem.date.name); // Date Name

export default responseItem;

// console.log(responseItem);
