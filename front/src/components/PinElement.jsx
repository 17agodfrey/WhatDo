import { Loader } from "@googlemaps/js-api-loader"

const apiKey = process.env.REACT_APP_GOOGLE_MAPS_API_KEY;
// const { Map } = await google.maps.importLibrary("maps");
// let map;


const loader = new Loader({
  apiKey: apiKey,
  version: "weekly",
});

const PinElement = async (background, borderColor, glyphColor) => {
    try {
      const { PinElement } = await loader.importLibrary('marker');
      const pin = new PinElement({
        background: background || 'white',
        borderColor: borderColor || 'white',
        glyphColor: glyphColor || 'white',
      });
      return pin;
    } catch (err) {
      console.error(err);
    }
  };

export default PinElement;