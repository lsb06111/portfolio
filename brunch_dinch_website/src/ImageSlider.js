import React, { useEffect, useState } from 'react';
import img1 from './img/banner1.png';
import { default as img2, default as img3 } from './img/banner2.png';

function ImageSlider() {
    const [currentSlide, setCurrentSlide] = useState(0);
    const images = [img1, img2, img3];
    const delay = 6000; // Delay in milliseconds

    useEffect(() => {
      const timer = setInterval(() => {
        setCurrentSlide((prevSlide) => (prevSlide + 1) % images.length);
      }, delay);

      return () => clearInterval(timer);
    }, []);

    const buttonContainerStyle = {
      position: 'absolute',
      bottom: '10px',
      left: '50%',
      transform: 'translateX(-50%)',
      display: 'flex',
      zIndex: 1
    };

    const buttonStyle = (index) => ({
      width: '10px',
      height: '10px',
      borderRadius: '50%',
      backgroundColor: currentSlide === index ? '#463E35' : 'white',
      margin: '0 5px',
      cursor: 'pointer',
    });

    return (
      <div style={{ position: 'relative', width: '100%', overflow: 'hidden' }}>
        <div 
          style={{ 
            display: 'flex', 
            width: `${100 * images.length}%`,
            height: '100%', 
            transition: 'transform 1s ease-in-out', 
            transform: `translateX(-${(100 / images.length) * currentSlide}%)`
          }}
        >
          {images.map((img, index) => (
            <img
              key={index}
              src={img}
              alt={`Slide ${index}`}
              style={{ width: `${100 / images.length}%`, height: '100%' }}
            />
          ))}
        </div>
        <div style={buttonContainerStyle}>
          {images.map((_, index) => (
            <div key={index} style={buttonStyle(index)} onClick={() => setCurrentSlide(index)} />
          ))}
        </div>
      </div>
    );
}

export default ImageSlider;
