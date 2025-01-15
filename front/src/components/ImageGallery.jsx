import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import Slider from "react-slick";
import { useRef, useEffect, useState, useContext } from 'react';
import "../styles/ImageGallery.css";



const NextArrow = (props) => {
    const { className, style, onClick } = props;
    return (
        <div
            className={className}
            style={{ ...style, display: "block" }}
            onClick={onClick}
        />
    );
};

const PrevArrow = (props) => {
    const { className, style, onClick } = props;
    return (
        <div
            className={className}
            style={{ ...style, display: "block", }}
            onClick={onClick}
        />
    );
};

const ImageGallery = ({ _imageUrls }) => {

    const sliderRef = useRef(null);

    const [imageUrls, setImageUrls] = useState(_imageUrls);

    const settings = {
        dots: true,
        infinite: true,
        centerMode: true,
        centerPadding: "80px",
        // adaptiveHeight: true,   
        speed: 500,
        slidesToShow: 1,
        slidesToScroll: 1,
        nextArrow: <NextArrow />,
        prevArrow: <PrevArrow />,
        // afterChange: handleAfterChange,
    };


    console.log('imageUrls', imageUrls);


    return (
        <>
            <style>
                {`
                    .slick-prev:before,
                    .slick-next:before {
                        color: red;
                        font-size: 40px;
                    }
                `}
            </style>
            <div 
                className="slider-container"
                style={{
                    width: '90%', 
                    minWidth: '90%', 
                }}
            >
                    <Slider ref={sliderRef} {...settings} className='img-slider'>
                        {imageUrls && imageUrls.map((image, index) => (
                            <div key={index} className='carousel-item'>
                                <img 
                                    src={image} 
                                    alt={`carousel-item-${index}`} 
                                />
                            </div>
                        ))}
                    </Slider>
            </div>        
        </>
    );
};

export default ImageGallery;