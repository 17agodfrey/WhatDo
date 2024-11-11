import { Loader } from "@googlemaps/js-api-loader"



const apiKey = process.env.REACT_APP_GOOGLE_MAPS_API_KEY;
// const { Map } = await google.maps.importLibrary("maps");
// let map;


const loader = new Loader({
  apiKey: apiKey,
  version: "weekly",
});

let infoWindow = null;
loader.importLibrary('maps').then(({ InfoWindow }) => {
  infoWindow = new InfoWindow({
    content: "dababy",
    ariaLabel: "Uluru",
    disableAutoPan: true,
  });
})

const mapI = async (center, mapId, zoom, gestureHandling, disableDefaultUI) => {
  try {
    const { Map } = await loader.importLibrary('maps');
    const map = new Map(document.getElementById('map_yeet'), {
      center: center,
      mapId: mapId,
      zoom: zoom,
      gestureHandling: gestureHandling,
      disableDefaultUI: disableDefaultUI,
    });
    return map;
  } catch (err) {
    console.error(err);
  }
};


class AdvancedMarkerElementWrapper {
  constructor(position, map, id, dateType, content, onClick, onHover, popupPicture, primaryColor, secondaryColor) {
    this.id = id;
    this.dateType = dateType;
    this.marker = null;
    this.highlighted = false;
    this.OGprimaryColor = primaryColor;
    this.OGsecondaryColor = secondaryColor

    this.initializeMarker(position, map, content, onClick, onHover, popupPicture);
  }

  async initializeMarker(position, map, content, onClick, onHover, popupPicture) {
    try {
      const { AdvancedMarkerElement } = await loader.importLibrary('marker');
      this.marker = new AdvancedMarkerElement({
        position: position,
        map: map,
        gmpClickable: true,
        content: content,
      });

      if (onClick) {
        this.marker.addListener('click', (ev) => onClick(ev, this.id));
      }

      if (onHover) {
        this.marker.content.addEventListener('mouseover', (ev) => onHover(ev, this.marker, this.id, popupPicture, true));
        this.marker.content.addEventListener('mouseout', (ev) => onHover(ev, this.marker, this.id, popupPicture, false));
      }
    } catch (err) {
      console.error(err);
    }
  }

  highlightMarker() {
    console.log('marker.content: ', this.marker.content);
    const pinElement = this.marker.content.querySelector('.RIFJN-maps-pin-view-border');
    if (pinElement) {
      pinElement.style.fill = '#7ACB7A';
      const backgroundElement = this.marker.content.querySelector('.RIFvHW-maps-pin-view-background');
      if (backgroundElement) {
        backgroundElement.style.fill = 'lightGreen';
      }
      const glyphElement = this.marker.content.querySelector('.KWCFZI-maps-pin-view-default-glyph');
      if (glyphElement) {
        glyphElement.style.fill = '#7ACB7A';
      }
      this.highlighted = true;
    }
  }

  unhighlightMarker() {
    const pinElement = this.marker.content.querySelector('.RIFJN-maps-pin-view-border');
    if (pinElement) {
      pinElement.style.fill = this.OGsecondaryColor;
      const backgroundElement = this.marker.content.querySelector('.RIFvHW-maps-pin-view-background');
      if (backgroundElement) {
        backgroundElement.style.fill = this.OGprimaryColor;
      }
      const glyphElement = this.marker.content.querySelector('.KWCFZI-maps-pin-view-default-glyph');
      if (glyphElement) {
        glyphElement.style.fill = this.OGsecondaryColor;
      }
      this.highlighted = false;
    }
  }
}

const pinElement = async (background, borderColor, glyphColor) => {
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

export { mapI, AdvancedMarkerElementWrapper, pinElement, infoWindow };