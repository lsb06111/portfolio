// src/Menu.js

import React, { useState } from 'react';
import './App.css';



const pointColour = '#6D6052';
const pointColourBold = '#463E35';
function Menu() {
    
    
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
        <p id='l_title' style={l_titleStyle}><strong>MENU</strong></p>
        <p style={l_sTitleStyle}>메뉴</p>
        </div>
        <MenuGallery/>


    </div>
    );
}




function MenuGallery() {
    const [category, setCategory] = useState('food');
    const importAll = (r) => {
        return r.keys().map(r);
      };
    
    
    const food_images = importAll(require.context('./img/menus_/food', false, /\.(png|jpe?g|svg)$/));
    const drinks_images = importAll(require.context('./img/menus_/drinks', false, /\.(png|jpe?g|svg)$/));

    const drinks_coffee = importAll(require.context('./img/menus_/drinks/coffee', false, /\.(png|jpe?g|svg)$/));
    const drinks_nonCoffee = importAll(require.context('./img/menus_/drinks/nonCoffee', false, /\.(png|jpe?g|svg)$/));

    const drinks_ade = importAll(require.context('./img/menus_/drinks/ade', false, /\.(png|jpe?g|svg)$/));
    const drinks_shake = importAll(require.context('./img/menus_/drinks/smoothie', false, /\.(png|jpe?g|svg)$/));
    const drinks_tea = importAll(require.context('./img/menus_/drinks/tea', false, /\.(png|jpe?g|svg)$/));
    const drinks_sherbet = importAll(require.context('./img/menus_/drinks/sherbet', false, /\.(png|jpe?g|svg)$/));
    const drinks_juice = importAll(require.context('./img/menus_/drinks/juice', false, /\.(png|jpe?g|svg)$/));


    const food_platter = importAll(require.context('./img/menus_/food/platter', false, /\.(png|jpe?g|svg)$/));
    const food_pizza = importAll(require.context('./img/menus_/food/pizza', false, /\.(png|jpe?g|svg)$/));
    const food_pasta = importAll(require.context('./img/menus_/food/pasta', false, /\.(png|jpe?g|svg)$/));
    const food_pilaf = importAll(require.context('./img/menus_/food/pilaf', false, /\.(png|jpe?g|svg)$/));
    const food_panini = importAll(require.context('./img/menus_/food/panini', false, /\.(png|jpe?g|svg)$/));
    const food_toast = importAll(require.context('./img/menus_/food/toast', false, /\.(png|jpe?g|svg)$/));
    const food_salad = importAll(require.context('./img/menus_/food/salad', false, /\.(png|jpe?g|svg)$/));
    const food_pancake = importAll(require.context('./img/menus_/food/pancake', false, /\.(png|jpe?g|svg)$/));
    const food_chicken = importAll(require.context('./img/menus_/food/chicken', false, /\.(png|jpe?g|svg)$/));




    const images = {
      food: food_images,
      drinks: drinks_images,
      drinks_coffee: drinks_coffee,
      drinks_ade: drinks_ade,
      drinks_shake: drinks_shake,
      food_pizza: food_pizza,
      food_platter: food_platter,
      food_pasta: food_pasta,
      food_pilaf: food_pilaf,
      food_panini: food_panini,
      food_toast: food_toast,
      food_salad: food_salad,
      food_chicken: food_chicken,
      food_pancake: food_pancake,
      drinks_tea: drinks_tea,
      drinks_sherbet: drinks_sherbet,
      drinks_juice: drinks_juice,
      drinks_nonCoffee: drinks_nonCoffee,


    };
  
    const changeCategory = (newCategory) => {
      setCategory(newCategory);
    };

    const buttonStyle = {
        width: '140px',
        height: '35px',
        fontWeight: '600',
        backgroundColor: '#FFF9EE',
        color: pointColourBold,
        fontSize: '16px',
        borderRadius: '3px',
        border: 'solid 2px #463E35',
        boxSizing: 'border-box',
        cursor: 'pointer',


    };

    const activeButtonStyle = {
        ...buttonStyle,
        backgroundColor: pointColourBold, // Different background color for the active button
        color: '#FFF9EE',

      };

    const buttonDiv={
        display: 'flex',
        justifyContent: 'center',
        gap: '2%',
        marginBottom: '2%',

    };

    const menuImgStyle ={
        width: '100%',
        height: 'auto',
    };
  
    const gridStyle = {
      display: 'grid',
      gridTemplateColumns: 'repeat(4, 1fr)',
      gridGap: '10px',
      // Add more styles as needed
    };

    const hrStyle = {
        flexGrow: 1, // Allows the line to take up the remaining space
        height: '2px',
        backgroundColor: pointColourBold,
        border: 'none',
      };

    const renderCategoryContent = () => {

        const s_titleStyle ={
            marginBottom: '0',
            fontSize: '15px',
            color: '#767676',
            
          };
        
          const l_titleStyle ={
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

          const rowStyle= {
            marginTop: '10%',
            marginBottom: '5%',
          };
          const titleStyle ={
            color: pointColourBold,
            fontWeight: 'bold',
            marginTop: '0px',
          }

          


        if (category === 'food') {
          return (
            <div>
                {/* pasta */}
                <div style={rowStyle}>
                    <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                        <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                            <p id='l_title' style={l_titleStyle}><strong>PASTA</strong></p>
                        </div>
                        <hr style={hrStyle} />
                        
                    </div>

                    <div className="grids" style={gridStyle}>
                        {images.food_pasta.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>


                <div style={rowStyle}>
                    <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                        <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                            <p id='l_title' style={l_titleStyle}><strong>RISOTOO & PILAF</strong></p>
                        </div>
                        <hr style={hrStyle} />
                        
                    </div>

                    <div className="grids" style={gridStyle}>
                        {images.food_pilaf.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>


                
                <div style={rowStyle}>
                    <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                        <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                            <p id='l_title' style={l_titleStyle}><strong>PLATTER</strong></p>
                        </div>
                        <hr style={hrStyle} />
                        
                    </div>

                    <div className="grids" style={gridStyle}>
                        {images.food_platter.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                <div style={rowStyle}>
                    <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                        <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                            <p id='l_title' style={l_titleStyle}><strong>PANINI</strong></p>
                        </div>
                        <hr style={hrStyle} />
                        
                    </div>

                    <div className="grids" style={gridStyle}>
                        {images.food_panini.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                <div style={rowStyle}>
                    <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                        <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                            <p id='l_title' style={l_titleStyle}><strong>FRENCH TOAST</strong></p>
                        </div>
                        <hr style={hrStyle} />
                        
                    </div>

                    <div className="grids" style={gridStyle}>
                        {images.food_toast.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                <div style={rowStyle}>
                    <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                        <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                            <p id='l_title' style={l_titleStyle}><strong>SALAD</strong></p>
                        </div>
                        <hr style={hrStyle} />
                        
                    </div>

                    <div className="grids" style={gridStyle}>
                        {images.food_salad.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                <div style={rowStyle}>
                    <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                        <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                            <p id='l_title' style={l_titleStyle}><strong>PIZZA</strong></p>
                        </div>
                        <hr style={hrStyle} />
                        
                    </div>

                    <div className="grids" style={gridStyle}>
                        {images.food_pizza.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                <div style={rowStyle}>
                    <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                        <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                            <p id='l_title' style={l_titleStyle}><strong>PANCAKES & CROIFFLE</strong></p>
                        </div>
                        <hr style={hrStyle} />
                        
                    </div>

                    <div className="grids" style={gridStyle}>
                        {images.food_pancake.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                <div style={rowStyle}>
                    <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                        <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                            <p id='l_title' style={l_titleStyle}><strong>CHICKEN & FRIES</strong></p>
                        </div>
                        <hr style={hrStyle} />
                        
                    </div>

                    <div className="grids" style={gridStyle}>
                        {images.food_chicken.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

            </div>
          );
        } else if (category === 'drinks') {
          return (
            
            <div>

                <div style={rowStyle}>
                <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                    <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                        <p id='l_title' style={l_titleStyle}><strong>COFFEE</strong></p>
                    </div>
                    <hr style={hrStyle} />
                    
                </div>

                <div className="grids" style={gridStyle}>
                        {images.drinks_coffee.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                <div style={rowStyle}>
                <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                    <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                        <p id='l_title' style={l_titleStyle}><strong>NON COFFEE</strong></p>
                    </div>
                    <hr style={hrStyle} />
                    
                </div>

                <div className="grids" style={gridStyle}>
                        {images.drinks_nonCoffee.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>
              
                <div style={rowStyle}>
                <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                    <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                        <p id='l_title' style={l_titleStyle}><strong>ADE</strong></p>
                    </div>
                    <hr style={hrStyle} />
                    
                </div>
                <div className="grids" style={gridStyle}>
                        {images.drinks_ade.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>
                <div style={rowStyle}>
                <div style={{ display: 'flex', alignItems: 'baseline', width: '100%', marginBottom: '3%' }}>
                    <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                        <p id='l_title' style={l_titleStyle}><strong>TEA</strong></p>
                    </div>
                    <hr style={hrStyle} />
                    
                </div>

                <div className="grids" style={gridStyle}>
                        {images.drinks_tea.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                <div style={rowStyle}>
                <div style={{ display: 'flex', alignItems: 'baseline', width: '100%' , marginBottom: '3%'}}>
                    <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                        <p id='l_title' style={l_titleStyle}><strong>SMOOTHIE</strong></p>
                    </div>
                    <hr style={hrStyle} />
                    
                </div>

                <div className="grids" style={gridStyle}>
                        {images.drinks_shake.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                <div style={rowStyle}>
                <div style={{ display: 'flex', alignItems: 'baseline', width: '100%' , marginBottom: '3%'}}>
                    <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                        <p id='l_title' style={l_titleStyle}><strong>SHERBET & FRAPPE</strong></p>
                    </div>
                    <hr style={hrStyle} />
                    
                </div>

                <div className="grids" style={gridStyle}>
                        {images.drinks_sherbet.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                <div style={rowStyle}>
                <div style={{ display: 'flex', alignItems: 'baseline', width: '100%' , marginBottom: '3%'}}>
                    <div style={{ display: 'inline-flex', alignItems: 'center' }}>
                        <p id='l_title' style={l_titleStyle}><strong>JUICE & BEER</strong></p>
                    </div>
                    <hr style={hrStyle} />
                    
                </div>

                <div className="grids" style={gridStyle}>
                        {images.drinks_juice.map((img, index) => {
                            // Extracting the file name without extension
                            const title = img.split('/').pop().split('.').shift();
                            return (
                            <div key={index} style={{ textAlign: 'center' }}> {/* Container for each image and title */}
                                <img style={menuImgStyle} src={img} alt={title} />
                                <p style={titleStyle}>{title}</p>
                            </div>
                            );
                        })}
                    </div>
                </div>

                
              
            </div>

            
          );
        }
      };
  
    return (
      <div>
        <div style={buttonDiv}>
        <button 
          style={category === 'food' ? activeButtonStyle : buttonStyle} 
          onClick={() => changeCategory('food')}>
          FOOD
        </button>
        <button 
          style={category === 'drinks' ? activeButtonStyle : buttonStyle} 
          onClick={() => changeCategory('drinks')}>
          DRINKS
        </button>
        </div>
        <div>
          {renderCategoryContent()}
        </div>
      </div>
    );
  }

export default Menu;
