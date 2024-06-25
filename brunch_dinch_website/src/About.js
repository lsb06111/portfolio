import React, { useEffect, useState } from 'react';
import './App.css';
import about1 from './img/about1.png'; // Update this path

import about1_1 from './img/about1_mob1.png';
import about1_2 from './img/about1_mob2.png';
import about1_3 from './img/about1_mob3.png';




const pointColour = '#6D6052';
const pointColourBold = '#463E35';

const historyData = [
    { year: "2020", image: about1, description: "Description for 2020" },
    { year: "2019", image: about1, description: "Description for 2019" },
    // Add more data as needed
  ];

function About() {
    const l_titleStyle ={
        fontSize: '60px',
        color: pointColourBold,
        marginTop: '0',
        marginBottom: '0',

    };

    const mainStyle ={
        padding: '8% 12% 0 12%', /* top | right | bottom | left */
    };

    const l_sTitleStyle= {
        fontWeight: 'bold',
        marginTop: '0',
        marginBottom: '5%',
        color: '#ADADAD',
    };

    const l_titleStyle2 ={
        marginTop: '0',
        marginBottom: '0',
        fontSize: '40px',
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

      const aboutImgStyle ={
        width: '100%',
      };

      const timelineStyle = {
        position: 'relative',
        paddingLeft: '50px', // Adjust as needed for left alignment
        paddingRight: '50px', // Adjust as needed for right alignment
      };
    
      const verticalLineStyle = {
        position: 'absolute',
        left: '50%',
        top: 0,
        bottom: 0,
        width: '2px',
        backgroundColor: pointColourBold,
        transform: 'translateX(-50%)',
      };

      const [isMobileView, setIsMobileView] = useState(window.innerWidth < 550);

    useEffect(() => {
        const handleResize = () => {
            setIsMobileView(window.innerWidth < 550);
        };

        window.addEventListener('resize', handleResize);
        return () => window.removeEventListener('resize', handleResize);
    }, []);

    return (

    <div  style={mainStyle}>
        <div className='aboutTitle' style={{width: '100%', textAlign:'center'}}>
        <p id='l_title' style={l_titleStyle}><strong>OUR COMPANY</strong></p>
        <p style={l_sTitleStyle}>브랜드 소개</p>
        </div>


        <div className='aboutFirstDiv' style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
            <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                <p  id='l_title' style={l_titleStyle2}><strong>BRUNCH & DINCH</strong></p>
            </div>
            <hr style={hrStyle} />
            
        </div>

        {isMobileView ? (
                <>
                    <img src={about1_1} style={aboutImgStyle} alt="About 1" />
                    <img src={about1_2} style={aboutImgStyle} alt="About 2" />
                    <img src={about1_3} style={aboutImgStyle} alt="About 3" />
                </>
            ) : (
                <img src={about1} style={aboutImgStyle} alt="About" />
            )}

        {/* <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%', marginTop:'5%', }}>
            <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                <p id='l_title' style={l_titleStyle2}><strong>OUR HISTORY</strong></p>
            </div>
            <hr style={hrStyle} />
            
        </div>

        <div style={timelineStyle}>
        <div style={verticalLineStyle}></div>
        {historyData.map((item, index) => (
          <TimelineItem 
            key={index}
            data={item}
            isLeftAligned={index % 2 === 0}
          />
        ))}
      </div> */}




    </div>
    );
}

function TimelineItem({ data, isLeftAligned }) {
    const timelineItemStyle = {
        display: 'flex',
        flexDirection: isLeftAligned ? 'row' : 'row-reverse',
        alignItems: 'center',
        marginBottom: '20px',
        position: 'relative',
        textAlign: isLeftAligned ? 'right' : 'left',
        marginLeft: isLeftAligned ? '5%' : '0',
        marginRight: isLeftAligned ? '0' : '5%',

        // Make sure the content does not overlap with the vertical line
      };

      const horizontalLineStyle = {
        position: 'absolute',
        height: '2px',
        backgroundColor: pointColourBold,
        top: '50%',
        left: isLeftAligned ? '50%' : undefined,
        right: isLeftAligned ? undefined : '50%',
        transform: isLeftAligned ? 'translateX(-50%)' : 'translateX(50%)', // Adjusts the starting point of the line
        width: '30px', // Adjust as needed
      };
  
    const imageStyle = {
      width: '100px', // Adjust as needed
      height: '100px', // Adjust as needed
      marginRight: isLeftAligned ? '0px' : '0',
      marginLeft: isLeftAligned ? '0' : '0px',
      
    };
  
    return (
        <div style={timelineItemStyle}>
          <div style={horizontalLineStyle}></div> {/* This is the horizontal line */}
          <div>
            <h4>{data.year}</h4>
            <img src={data.image} alt={`About ${data.year}`} style={imageStyle} />
            <p>{data.description}</p>
          </div>
        </div>
      );
    }
  

export default About;
