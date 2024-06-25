

import React from 'react';
import './App.css';

const pointColour = '#6D6052';
const pointColourBold = '#463E35';

function Franchise() {
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

    return (

    <div style={mainStyle}>
        <div className='aboutTitle' style={{width: '100%', textAlign:'center'}}>
        <p id='l_title' style={l_titleStyle}><strong>FRANCHISE</strong></p>
        <p style={l_sTitleStyle}>가맹 문의</p>
        </div>



        <p style={{textAlign: 'center', fontWeight: 'bold'}}>보다 완벽한 정보 제공을 위해 준비중입니다.</p>
        <p style={{textAlign: 'center', fontWeight: 'bold', marginBottom: '15%'}}>빠른 시일 내에 완료될 예정입니다.</p>




    </div>
    );

}

export default Franchise;
