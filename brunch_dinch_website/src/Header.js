import React, { useState } from 'react';
import { Link } from 'react-router-dom';

import './Header.css';
import logo2 from './img/bd_logo_black.png'; // Update this path


function Header() {

    const [isSidebarOpen, setIsSidebarOpen] = useState(false);

    const toggleSidebar = () => {
        setIsSidebarOpen(!isSidebarOpen);
    };


    const linkStyle = {
        textDecoration: 'none', // Removes the underline
        fontWeight: '800',
        color: '#FFF9EE', // Optional: Ensures the links use the current text color
      };

    const buttonStyle ={
        backgroundColor: '#463E35',
        width:'120px',
        height: '40px',
        color:'#FFF9EE',
        border: 'none',
        borderRadius: '3px',
        fontWeight: 'bold',
        marginRight: '40px',
        cursor: 'pointer',
        fontSize: '15px',
    };

    const logoContainerStyle = {
        flex: 1,
        display: 'flex',
        alignItems: 'center', // Align items vertically in the center
        justifyContent: 'flex-start',
        marginLeft: '40px',
      };
    
      const logoStyle = {
        maxHeight: '100%', // Limit the height of the image
        maxWidth: '150px', // Limit the width of the image
        height: 'auto', // Maintain aspect ratio
        width: 'auto', // Maintain aspect ratio
      };

      const headerStyle ={
        display: 'flex', 
        justifyContent: 'space-between', 
        alignItems: 'center', 


      }
      const toggleNav = () => {

      };

      const sidebarStyle = {
        position: 'fixed',
        top: 0,
        right: isSidebarOpen ? 0 : '-100%', // Offscreen when closed
        width: '55%', // Sidebar width
        height: '100%',
        backgroundColor: '#463E35',
        transition: 'right 0.3s ease',
        zIndex: 1001, // Above other content
        padding: '10px',
        paddingLeft: '0 !important',
    };

    const closeButtonStyle ={
        
        color: '#FFF9EE',
        background: 'none',
        border: 'none',
        fontSize: '20px',
        float: 'right',
        fontWeight: 'bold',

    }

    const linkStyle2 = {
        textDecoration: 'none', // Removes the underline
        fontWeight: '800',
        color: '#FFF9EE',
    }

  return (
    <header style={headerStyle} className='header'>
      {/* Logo */}
      <div className="logo-container" >
        <Link to="/" style={{ display: 'flex', alignItems: 'center', height: '100%' }}>
          <img  src={logo2} alt="브런치앤딘치" style={logoStyle} />
        </Link>
      </div>

      {/* Navigation Links */}
      <nav className="nav-bar">
        <ul style={{ listStyle: 'none', display: 'inline-flex', gap: '20px', margin: '0', padding: '0' }}>
          <li><Link to="/about" className="nav-link" style={linkStyle}>브랜드 소개</Link></li>
          <li><Link to="/menu"  className="nav-link" style={linkStyle}>메뉴</Link></li>
          <li><Link to="/franchise-inquiry"  className="nav-link" style={linkStyle}>가맹 문의</Link></li>
          <li><Link to="/help"  className="nav-link" style={linkStyle}>고객 센터</Link></li>
          <li><Link to="/qa"  className="nav-link" style={linkStyle}>FAQ</Link></li>
        </ul>
      </nav>

      {/* Inquiry Button */}
      <div className="inquiry-button" >
        <button style={buttonStyle}>가맹 문의</button>
      </div>

      <div className='mob-navB'>
        <button onClick={toggleSidebar} className='hamburger-button'>☰</button>

      </div>

        {/* Sidebar for Mobile View */}
        <div style={sidebarStyle}>
                <button style={closeButtonStyle} onClick={toggleSidebar}>X</button>
                <ul style= {{listStyleType: 'none', paddingLeft: '20px', marginTop: '20%',}}>
                    <li style={{marginBottom: '15px'}}><Link to="/about" onClick={toggleSidebar} style={linkStyle2}>브랜드 소개</Link></li>
                    <li style={{marginBottom: '15px'}}><Link to="/menu" onClick={toggleSidebar} style={linkStyle2}>메뉴</Link></li>
                    <li style={{marginBottom: '15px'}}><Link to="/franchise-inquiry" onClick={toggleSidebar} style={linkStyle2}>가맹 문의</Link></li>
                    <li style={{marginBottom: '15px'}}><Link to="/help" onClick={toggleSidebar} style={linkStyle2}>고객 센터</Link></li>
                    <li><Link to="/qa" onClick={toggleSidebar} style={linkStyle2}>FAQ</Link></li>
                </ul>
            </div>

    </header>
  );
}

export default Header;