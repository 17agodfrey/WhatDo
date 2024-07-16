import shrek from '../assets/shrek.jpg';

const mapDatesResponseBox = ({ mapResult }) => {
    // const image = mapResult.Photos[0].authorAttributions[0].url;

    return (
        <div className='map-dates-response-box'>
            <img src={shrek} alt="date image" />
            <div className='date-response-info'>
                <h3>Name: {mapResult.displayName}</h3>
                <p>Description: {mapResult.description}</p>
                <p>Price: {mapResult.price}</p>
                <p>Rating: {mapResult.rating}</p>
                <p>Location: {mapResult.location}</p>
                {/* <h3>Name: {mapDatesResponse.date.dateName}</h3>
                <p>Description: {mapDatesResponse.date.description}</p>
                <p>Duration: {mapDatesResponse.date.duration}</p>
                <p>Price: {mapDatesResponse.date.price}</p>
                <p>Rating: {mapDatesResponse.date.rating}</p>
                <p>Activity Level: {mapDatesResponse.date.activityLevel}</p>
                <p>Indoor/Outdoor: {mapDatesResponse.date.indoorOutdoor}</p> */}
            </div>
        </div>
    );
}


export default mapDatesResponseBox;