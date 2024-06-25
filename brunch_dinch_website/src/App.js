
import React, { useEffect, useRef, useState } from 'react';
import { Route, HashRouter as Router, Routes } from 'react-router-dom';
import About from './About';
import './App.css';
import Franchise from './Franchise';
import Header from './Header';
import Help from './Help';
import ImageSlider from './ImageSlider';
import Menu from './Menu';
import Qa from './Qa';
import bannerImage from './img/banner.png'; // Import the image
import cvacf from './img/cvacf.png';
import flavourIcon from './img/flavour.png';
import interior1 from './img/interior1.png';
import interior2 from './img/interior2.png';
import interiorIcon from './img/interiorIcon.png';
import logo2 from './img/logo_black.png'; // Update this path
import ourBrandImage from './img/ourBrand.png';
import ourBrandImage_mob from './img/ourBrand_mob.png';

import quantityIcon from './img/quantityIcon.png';
import priceIcon from './img/reasonable_price.png';

import { Link } from 'react-router-dom';
import ScrollToTop from './ScrollToTop';



const pointColour = '#6D6052';
const pointColourBold = '#463E35';


function App() {
  const bannerBackground = {
    backgroundImage: `url(${bannerImage})`, // Use the imported image
    backgroundSize: 'cover',
    backgroundPosition: 'center',
    height: '600px',
    width: '100%',
  };
  return (

    
    <Router>

      <ScrollToTop />
      <div>
      <Header />
      </div>
      <Routes>
        <Route path="/" element={<Home />} />
          <Route path="/menu" element={<Menu />} />
          <Route path="/about" element={<About />} />
          <Route path="/franchise-inquiry" element={<Franchise />} />
          <Route path="/help" element={<Help />} />
          <Route path="/qa" element={<Qa />} />
          
        </Routes>
      <Footer />
      
    </Router>
  );
}

function Home() {
  const mainStyle ={ 
    padding: '8% 12% 0 12%', /* top | right | bottom | left */
  };

  const s_titleStyle ={
    marginBottom: '0',
    fontSize: '15px',
    color: '#767676',
    
  };

  const l_titleStyle ={
    marginTop: '0',
    marginBottom: '0',
    fontSize: '50px',
    display: 'inline-flex', // Display inline to align with the horizontal line
    marginRight: '40px',
    width: '100%',
    color: pointColourBold,

  };

  const hrStyle = {
    flexGrow: 1, // Allows the line to take up the remaining space
    height: '2px',
    backgroundColor: pointColourBold,
    border: 'none',
  };

  const obiStyle ={
    width: '100%',
    display: 'block',
    margin: 'auto',
    marginBottom: '10%',
  };

  const cvacfStyle = {
    width: '100%',
    display: 'block',
    margin: 'auto',
  };

  const contents ={
    textAlign: 'center',

    fontSize: '17px',
    width: '100%',
    margin: 'auto',
    letterSpacing: '1px',
  };
  
  const iconImages ={
    width: '55%',
  };

  

  const iconDescription = {
    fontWeight:'bold',
    color: pointColourBold,
    marginTop: '0',
  };

  const moreMenuButton = {
    color: pointColourBold,
    fontWeight: 'bold',
    style: 'none',
  };

  const menuBDiv = {
    marginTop:'3%',
  };
  
  const [currentImage, setCurrentImage] = useState(ourBrandImage);

    useEffect(() => {
        const handleResize = () => {
            if (window.innerWidth < 550) {
                setCurrentImage(ourBrandImage_mob);
            } else {
                setCurrentImage(ourBrandImage);
            }
        };

        // Call the function on component mount
        handleResize();

        // Add event listener
        window.addEventListener('resize', handleResize);

        // Remove event listener on cleanup
        return () => window.removeEventListener('resize', handleResize);
    }, []);


    const [showExtraBreak, setShowExtraBreak] = useState(false);

    useEffect(() => {
        const handleResize = () => {
            setShowExtraBreak(window.innerWidth < 550);
        };

        // Call the function on component mount
        handleResize();

        // Add event listener
        window.addEventListener('resize', handleResize);

        // Remove event listener on cleanup
        return () => window.removeEventListener('resize', handleResize);
    }, []);


    const [isMobileView, setIsMobileView] = useState(window.innerWidth < 550);

  useEffect(() => {
    const handleResize = () => {
      setIsMobileView(window.innerWidth < 550);
    };

    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  const containerStyle = isMobileView ? {
    display: 'grid', // Use grid layout for mobile view
    gridTemplateColumns: '1fr 1fr', // Two columns
    gridGap: '20px', // Gap between grid items
    width: '100%',
    marginTop: '10%',
  } : {
    display: 'flex', // Aligns children (images) in a row
    justifyContent: 'space-around', // This will space the images evenly
    width: '100%',
    marginTop: '10%',
  };

  const iconDivStyle = {
    width: isMobileView ? '100%' : '25%', // Full width for mobile, 25% for desktop
    textAlign: 'center',
  };


  return (
    <div>
      <div className='imageSlider'>
      <ImageSlider />

      </div>
      <div className='main'>

        <div className='ourBrand' style={mainStyle}>
          <p id='s_title' style={s_titleStyle}>Brunch & Dinch</p>

          <div style={{ display: 'flex', alignItems: 'baseline', width: '100%' }}>
          <div style={{ display: 'inline-flex', alignItems: 'center' }}>
            <p id='l_title' style={l_titleStyle}><strong>OUR BRAND</strong></p>
          </div>
          <hr style={hrStyle} />
        </div>

        <img className='ourBrandImage' src={currentImage} style={obiStyle}></img>
        <img className='cvacf' src={cvacf} style={cvacfStyle}></img>
        
        <p className='obP' style={contents}>
                브런치 앤 딘치는 고객 모두의 가치를 항상 앞서 생각하는 특별한 브랜드 입니다.
                <br></br>
                {showExtraBreak && <br></br>}
                고객 모두가 소중한 시간을 내어주신 만큼 든든하고 맛있는 브런치로 보답드리려고 합니다.
            </p>

        <div className='icons' style={containerStyle}>
          <div style={iconDivStyle}>
            <img src={priceIcon} alt="합리적인 가격" style={iconImages}></img>
            <p style={iconDescription}>합리적인 가격</p>
          </div>

          <div style={iconDivStyle}>
            <img src={quantityIcon} alt="푸짐하고 만족스러운 양" style={iconImages}></img>
            <p style={iconDescription}>푸짐하고 만족스러운 양</p>
          </div>

          <div style={iconDivStyle}>
            <img src={flavourIcon} alt="맛의 풍미가 가득한 요리" style={iconImages}></img>
            <p style={iconDescription}>맛의 풍미가 가득한 요리</p>
          </div>

          <div style={iconDivStyle}>
            <img src={interiorIcon} alt="편안하고 모던한 분위기" style={iconImages}></img>
            <p style={iconDescription}>편안하고 모던한 분위기</p>
          </div>
        </div>

        {/* <div class="grid-container">
          <div class="grid-item">
            <div class="grid-content">
              합리적인 가격
            </div>
          </div>
          <div class="grid-item">
            <div class="grid-content">
              편안하고 모던한 분위기
            </div>
          </div>
          <div class="grid-item">
            <div class="grid-content">
              맛의 풍미가 가득한 요리
            </div>
          </div>
          <div class="grid-item">
            <div class="grid-content">
              푸짐하고 만족스러운 양
            </div>
          </div>
        </div> */}


        </div>

        <div className='ourBrand' style={mainStyle}>
        <p id='s_title' style={s_titleStyle}>Brunch & Dinch</p>

        <div style={{ display: 'flex', alignItems: 'baseline', width: '100%' }}>
          <div style={{ display: 'inline-flex', alignItems: 'center' }}>
            <p id='l_title' style={l_titleStyle}><strong>INTERIOR</strong></p>
          </div>
          <hr style={hrStyle} />
        </div>

        <p className='intP' style={{margin: '4% 0 4% 0'}}>브런치 앤 딘치는 이국적인 매력과 자연친화적인 분위기를 세련되게 조화시켜 모던함과 편안함이 공존하는 독특한 공간을 선사합니다. 
          <br></br>
          {showExtraBreak && <br></br>}

          각 디테일에서 느껴지는 우아함과 따뜻함이 고객들에게 잊지 못할 경험을 제공합니다.</p>


        
        <DiagonalSplitImages />


        </div>


        <div className='ourBrand' style={mainStyle}>
          <p id='s_title' style={s_titleStyle}>Brunch & Dinch</p>

          <div style={{ display: 'flex', alignItems: 'baseline', width: '100%' }}>
            <div style={{ display: 'inline-flex', alignItems: 'center' }}>
              <p id='l_title' style={l_titleStyle}><strong>MENU</strong></p>
            </div>
            <hr style={hrStyle} />
          </div>

          <p className='intP' style={{margin: '4% 0 4% 0'}}>저희 브런치카페는 합리적인 가격에 푸짐하고 만족스러운 양을 제공하며 각 메뉴는 엄선된 식재료를 사용하여 뛰어난 맛의 조화를 이룹니다. 
          <br></br>
          {showExtraBreak && <br></br>}
          고객 여러분이 즐기는 모든 순간이 기억에 남는 맛의 경험으로 완성됩니다.</p>

          <MenuSlider />
            
            
          <div style={menuBDiv}>
          <Link to="/menu" style={moreMenuButton}>메뉴 더보기</Link>
          </div>


          




        </div>


        



        

      </div>
      
    </div>

    
  );
}

function Footer() {
  const footerStyle = {
    backgroundColor: pointColour, 
    color: 'white', 
    textAlign: 'center', 
    padding: '20px 0',
    display: 'flex',
    justifyContent: 'center', // Center horizontally
    alignItems: 'center', // Center vertically
    width: '100%',
    flexDirection: 'row', // Align children in a row

    marginTop: '5%',
  };

  const contentStyle = {
    textAlign: 'left',
    padding: '0',
    display: 'flex',
    flexDirection: 'column', // Align content in a column
    justifyContent: 'center', // Center content vertically within the div
  };
  const logoStyle2 = {
    maxHeight: '100%', // Limit the height of the image
    maxWidth: '150px', // Limit the width of the image
    height: 'auto', // Maintain aspect ratio
    width: 'auto', // Maintain aspect ratio
  };
  const paraStyle ={
    marginBottom: '0',
    marginTop: '0',
    color:'#ADADAD',
    fontSize: '13px'
  }
  return (
    <footer style={footerStyle}>
      <img className='footerImg' src={logo2} style={logoStyle2}></img>

      <div className='footerContents' style={contentStyle}>
      <p style={paraStyle}>인천 남동구 서창남순환로10번길 53 2층</p>
      <p style={paraStyle}>사업자 번호: 893-02-03102</p>
      <p style={paraStyle}>이메일: brunchdinch99@gmail.com</p>
      <p style={paraStyle}>전화번호: 032-466-4073</p>

      {/* <div>
        <a href="https://www.facebook.com" target="_blank" rel="noopener noreferrer">Facebook</a> |
        <a href="https://www.instagram.com" target="_blank" rel="noopener noreferrer">Instagram</a> |
        <a href="https://www.twitter.com" target="_blank" rel="noopener noreferrer">Twitter</a>
      </div> */}
      <p style={paraStyle}>Brunch & Dinch © 2023. All rights reserved.</p>

      </div>
      
    </footer>
  );
}



function MenuSlider() {
  const importAll = (r) => {
    return r.keys().map(r);
  };


  const images = importAll(require.context('./img/menus_', false, /\.(png|jpe?g|svg)$/));
  const [sliderValue, setSliderValue] = useState(0);
  const imageContainerRef = useRef(null);

  const handleSliderChange = (event) => {
    const newPosition = event.target.value;
    setSliderValue(newPosition);

    // Calculate the scroll position
    const scrollPosition = (imageContainerRef.current.scrollWidth - imageContainerRef.current.clientWidth) * (newPosition / 100);
    imageContainerRef.current.scrollLeft = scrollPosition;
  };

  const imageContainerStyle = {
    display: 'flex',
    overflowX: 'auto',
    scrollBehavior: 'smooth',
  };

  const imageStyle = {
    width: '25%', // Display 4 images at a time
    flexShrink: 0, // Prevent images from shrinking
  };

  const scrollbarStyle = `
    .custom-scrollbar::-webkit-scrollbar-track {
      background: none;
    }
    .custom-scrollbar::-webkit-scrollbar-thumb {
      background-color: #463E35;
      border-radius: 10px;
    }
    .custom-scrollbar::-webkit-scrollbar-thumb:hover {
      background: #555;
    }
    .custom-scrollbar::-webkit-scrollbar {
      width: 10px;
      height: 8px;
    }
  `;

  return (
    <div>
      <style>{scrollbarStyle}</style>
      <div ref={imageContainerRef} style={imageContainerStyle} className="custom-scrollbar">
        {images.map((img, index) => (
          <img className='menuSliderImages' key={index} src={img} alt={`Slide ${index}`} style={imageStyle} />
        ))}
      </div>
      {/* <input 
        type="range" 
        min="0" 
        max="100" 
        value={sliderValue}
        onChange={handleSliderChange}
        style={{ width: '100%', marginTop: '10px' }}
      /> */}
    </div>
  );
}



function DiagonalSplitImages() {
  const [activeImage, setActiveImage] = useState(null); // 'first', 'second', or null

  const sectionStyle = {
    display: 'flex',
    width: '100%',
    paddingTop: '56.25%', // for a 16:9 aspect ratio
    boxSizing: 'border-box',
    position: 'relative',
  };

  const diagonalHoverBaseStyle = {
    position: 'absolute',
    width: '66%',
    height: '100%',
    transition: 'all 0.3s ease-out',
    backgroundRepeat: 'no-repeat',
    backgroundSize: 'cover',
  };

  const getStyle = (imageName) => ({
    ...diagonalHoverBaseStyle,
    zIndex: activeImage === imageName ? 2 : 1,
    backgroundImage: `url(${imageName === 'first' ? interior1 : interior2})`,
    WebkitClipPath: imageName === 'first' 
      ? 'polygon(0 0, 100% 0%, 50% 100%, 0% 100%)' 
      : 'polygon(50% 0, 100% 0%, 100% 100%, 0% 100%)',
    clipPath: imageName === 'first' 
      ? 'polygon(0 0, 100% 0%, 50% 100%, 0% 100%)' 
      : 'polygon(50% 0, 100% 0%, 100% 100%, 0% 100%)',
    left: imageName === 'first' ? 0 : 'auto',
    right: imageName === 'second' ? 0 : 'auto',
    top:0,
  });

  return (
    <div>
      <section style={sectionStyle}>
        <div
          className="diagonalHover"
          style={getStyle('first')}
          onMouseEnter={() => setActiveImage('first')}
        ></div>
        <div
          className="diagonalHover"
          style={getStyle('second')}
          onMouseEnter={() => setActiveImage('second')}
        ></div>
      </section>
    </div>
  );
}




export default App;
