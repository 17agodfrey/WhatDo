// Date class
export class Date {
    constructor(id, name, duration, activityLevel, indoorOutdoor) {
        this.id = id;
        this.name = name;
        this.duration = duration;
        this.activityLevel = activityLevel;
        this.indoorOutdoor = indoorOutdoor;
    }
}

// FindMapDatesResult class
export class FindMapDatesResult {
    constructor(
        googleMapsId, 
        displayName, 
        latLng, 
        description, 
        priceLevel, 
        rating, 
        photos, 
        // photosUris, 
        dateType
    ) {
        this.googleMapsId = googleMapsId;
        this.displayName = displayName;
        this.latLng = latLng;
        this.description = description !== null ? description : "no description provided";
        this.price = priceLevel !== null ? priceLevel : "no price level";
        this.rating = rating !== null ? rating : "no rating";
        this.photos = photos;
        // this.photosUris = photosUris;
        this.dateType = dateType;
    }
}

// FindMapDatesResponseItem class - contains a Date and an array of FindMapDatesResult
export class FindMapDatesResponseItem {
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

export const ex_responseItem = new FindMapDatesResponseItem(date, [result1]);

// console.log(responseItem.date.name); // Date Name

// console.log(responseItem);
