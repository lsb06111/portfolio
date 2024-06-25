

import React from 'react';
import './App.css';
import FaqItem from './FaqItem';

const pointColour = '#6D6052';
const pointColourBold = '#463E35';

function Qa() {
  const l_titleStyle = {
    fontSize: '60px',
    color: pointColourBold,
    marginTop: '0',
    marginBottom: '0',
  };

  const mainStyle = {
    padding: '8% 12% 0 12%',
  };

  const l_sTitleStyle= {
    fontWeight: 'bold',
    marginTop: '0',
    marginBottom: '5%',
    color: '#ADADAD',
  }

  const faqs = [
    { question: "브런치 앤 딘치 뜻이 무엇인가요?", answer: "Brunch (브런치) = Breakfast (아침) + Lunch (점심) <br> Dinch (딘치) = Dinner (저녁) + Lunch (점심) <br> 위와 같이 아침부터 저녁까지 모두 즐길 수 있는 식사를 제공한다는 뜻을 가지고 있습니다." },
    { question: "매장 영업 시간이 어떻게 되나요?", answer: "10:00AM ~ 09:00PM <br> 브레이크 타임: 03:00PM ~ 04:00PM <br> 라스트 오더: 08:00PM"},
    { question: "가맹상담 운영시간은 어떻게 되나요?", answer: "오전 10시부터 오후 9시까지 상담 가능 합니다. <br> 운영 시간 이후에는 이메일 혹은 카카오톡으로 문의 내용을 남겨주세요."},
    { question: "고객센터 운영시간은 어떻게 되나요?", answer: "오전 10시부터 오후 9시까지 상담 가능 합니다. <br> 운영 시간 이후에는 이메일 혹은 카카오톡으로 문의 내용을 남겨주세요."},
    { question: "가맹 문의 절차가 어떻게 되나요?", answer: "step 1. 창업 및 가맹 상담<br>step 2. 상권 분석 및 점포 선정<br>step 3. 정식 계약 체결<br>step 4. 인테리어 시공<br>step 5. 조리 및 운영 교육<br>step 6. 가오픈 및 리허설<br>step 7. 정식 오픈 및 경영 관리 <br> 자세한 사항은 가맹문의를 확인해주세요." },



    

    // Add more FAQs as needed
  ];

  return (
    <div style={mainStyle}>
      <div className='aboutTitle' style={{ width: '100%', textAlign: 'center' }}>
        <p id='l_title' style={l_titleStyle}><strong>FAQ</strong></p>
        <p style={l_sTitleStyle}>자주 묻는 질문</p>
      </div>
      {faqs.map((faq, index) => (
        <FaqItem key={index} question={faq.question} answer={faq.answer} isFirstItem={index === 0} isLastItem={index === faqs.length -1} />
      ))}
    </div>
  );
}


export default Qa;
