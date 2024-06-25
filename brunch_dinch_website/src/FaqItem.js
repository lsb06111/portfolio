import { faChevronDown } from '@fortawesome/free-solid-svg-icons';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React, { useState } from 'react';
import './App.css';

function FaqItem({ question, answer, isFirstItem, isLastItem }) {
  const [isOpen, setIsOpen] = useState(false);
  const pointColour = '#6D6052';
  const pointColourBold = '#463E35';
  const toggleOpen = () => {
    setIsOpen(!isOpen);
  };

  const faqItemStyle = {
    cursor: 'pointer',
    marginBottom: '10px',
    paddingLeft: '15px',
    paddingRight: '15px',
    paddingTop: '0',
    width: '70%',
    margin: 'auto',
    borderTop: 'solid 1px',
    borderLeft: 'solid 1px',
    borderRight: 'solid 1px',
    borderBottom: isLastItem ? 'solid 1px' : 'none', // Conditional bottom border
    borderTopLeftRadius: isFirstItem ? '3px' : '0',
    borderTopRightRadius: isFirstItem ? '3px' : '0',
    borderBottomLeftRadius: isLastItem ? '3px' : '0',
    borderBottomRightRadius: isLastItem ? '3px' : '0',
    marginBottom: isLastItem ? '15%' : '0',
    // ... other styles
  };

  const faqAnswerStyle = {
    maxHeight: isOpen ? '200px' : '0',
    overflow: 'hidden',
    transition: 'max-height 0.3s ease',
    
  };

  const createMarkup = (html) => {
    return { __html: html };
  };

  const qStyle ={
    fontSize: '20px',
    fontWeight: 'bold',
    margin: '1.5%',
    color: pointColourBold,
    wordWrap: 'break-word',
  }
  const aStyle ={
    fontSize: '16px',
    fontWeight: 'bold',
    margin: '1%',
    color: pointColour,
    lineHeight: '1.3',

  }

  const iStyle={
    fontSize: '16px',
    transition: 'transform 0.3s ease', // Add transition
    transform: isOpen ? 'rotate(180deg)' : 'rotate(0deg)',
  }

  return (
    <div className='faqItem' style={faqItemStyle} onClick={toggleOpen}>
      <p style={qStyle}>Q. {question} <FontAwesomeIcon icon={faChevronDown} style={iStyle} /></p>
      <div style={faqAnswerStyle}>
      <div style={aStyle} dangerouslySetInnerHTML={createMarkup(answer)} />
      </div>
    </div>
  );
}

export default FaqItem;
