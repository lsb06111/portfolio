var character;
var c_Armor=30; // 30% reduce the damage
var c_Health=41;
var c_Attack=5;

var door;
var ice;
var icestart;

var tick;

var button3;
var monster;
var m_Armor=13;
var m_Health=30;
var m_Attack=5;

var unmute;
var mute;

var buttonStart =0;
var started =0;
var howto=0;

var countA=0;
var countD=0;
var countH=0;

var xpos=66;
var ypos = 727;
var gameStart = false;
var pracX = 395;
var pracY = 670;

var monsterDead;

var alive = true;

var greater = 17; // minus
var smaller = 67; // plus

var monster1;
var level =1;
var score =0;
var highScore=0;
var enemyX = 941;
var enemyY = 320;
var start = false;
var button;
var button1;
var button2;

var musicMute =false;
var rule1=0;

var atkbuttonC;
var defbuttonC;
var hpbuttonC;
var downAtC;
var downAtD;
var downAtH;


var attackButton;
var armorButton;
var healthButton;
var upgradeButton;
//41
var increA=0;
var increD=0;
var increH=41;

var numberA=0;
var numberD=0;
var numberH=0;

var hp=c_Health;

var characterI;
var monsterI;
var attackI;
var armourI;
var healthI;
var iceberg;
var igloo;
var backgroundphoto;

var isOn=true;

var gameRule;

var backgroundmusic;
var downAt;
var downAr;
var downH;

var upgraded = true;

var doorX=590;
var doorY=286;

var sword;

var count=0;
var coin;
var coins=0;



function preload() {
  // load any assets (images, sounds etc.) here
  monsterI = loadImage("assets/garbage-monster.png");
  characterI = loadImage("assets/hero.png");

  attackI = loadImage("assets/attack.png");
  armourI = loadImage("assets/shield.png");
  healthI = loadImage("assets/exercise.png");
  iceberg = loadImage("assets/iceberg.png");
  igloo = loadImage("assets/igloo.png");
  backgroundphoto = loadImage("assets/background.jpg");

  monsterDead = loadSound('assets/monsterDead.wav');
  sword = loadSound('assets/sword1.wav');
  backgroundmusic = loadSound('assets/back.mp3');

  unmute = loadImage("assets/unmute.png");
  mute = loadImage("assets/mute.png");

  coin = loadImage("assets/coins.png");
  door = loadImage("assets/door.png");
  ice = loadImage("assets/ice.png");
  icestart = loadImage("assets/startButton.png");
  tick =loadImage("assets/tick.png");

}

function setup() {
  createCanvas(1440, 790);

  character = {ar: c_Armor, h: c_Health, at: c_Attack};
  monster = {ar: m_Armor, h: m_Health, at: m_Attack};
  monster1 = {ar: m_Armor, h: m_Health, at: m_Attack};
  nature ={x1:680, y1:370, bigX: 700, bigY: 790-370};

  

  


  backgroundmusic.play();
  


  


}
//score and high

function draw() {
  // your persuasive arcade game code goes here
  // but its also a good idea to write some functions
  // which deal with specific parts of your game (like drawing things)



background(backgroundphoto); // background

fill(0);

if(isOn){
  image(unmute,1200,15,50,50);
}else if(!isOn) image(mute,1200,15,50,50);



fill(51,60);
stroke(45);
rect(0,0,1150,55);

fill(40,150,50); // upgrade field
//rect(0,400,500,windowHeight-400); // add virtual enemy so the user can know how good their ability is.
image(igloo, -40,430,550,790-400);
fill(0);
//rect(30,590,70,100);
fill(255,0,0);
//rect(pracX,pracY,50,50);
image(monsterI,pracX-3.5,pracY-8,monsterI.width/3,monsterI.height/3);
fill(255);
rect(pracX+8,pracY+55,32,6);
fill(255,0,0);
rect(pracX+9,pracY+55.5,monster1.h,5);



fill(100,100,255); // ice
//rect(nature.x1,nature.y1,nature.bigX,nature.bigY);
image(iceberg,nature.x1-15,nature.y1-110,nature.bigX+40,nature.bigY+150);

//rect(doorX,doorY,70,90);
strokeWeight(5);
line(doorX+65,doorY+85,doorX+100,doorY+85);
image(door, doorX, doorY,70,90);
strokeWeight(1);



fill(255);
image(armourI,160,10,30,35);
textFont('Georgia');
textSize(25);
text(character.ar,200,34);

//rect(220,510,30,30);
image(attackI,6,10,30,35);
text(character.at,55,34);


//rect(440-66,510,30,30);
image(healthI,326,10,30,35);
text(int(character.h)+" / "+hp,368,36);

image(coin, 1000,10,30,35);
text("coins: "+coins,1040,35);

fill(0);

if(musicMute == false&&!backgroundmusic.isPlaying()){
  backgroundmusic.play();
}

textSize(30);
/*
text("x: "+xpos, 20, 50);
text("y: "+ypos, 20, 100);
text("monster's health: "+monster.h, 20,150);
*/
fill(255);

text("score: "+score,630,35);
text("Level: "+level,480,35);
text("High score: "+highScore,780,35);
fill(0);
/*
text("character's health: "+character.h, 120,50);
text("character's attack: "+character.at, 120,100);
text("character's armor: "+character.ar, 450,50);
text("gameStart: "+gameStart,450,100);
text("prac_health: "+monster1.h,20,300);
*/

if(gameStart==false){
  if(xpos<=20) xpos=20;
  if(xpos>=480) xpos=480;
  if(ypos>=790-20) ypos=790-20;
  if(ypos<=470) ypos=470;
}
else if(gameStart==true){
  

  if(xpos<=doorX+10) xpos=doorX+10;
  if(xpos>=1360) xpos=1360;

  

  if(frameCount%10==0){
    nature.y1 +=1.5;
    enemyY +=1.5;
    ypos+=1.5;
    doorY+=1.5;
    
    
    

  }
  

}
if(nature.y1<370||enemyY<320) {
  nature.y1=370;
  enemyY=320;}


  fill(255,25);
  noStroke();
  rect(10,100,250,300);
  stroke(0);
  fill(0);
  textSize(12);
  text("ATK",70,125);
  fill(255);

  rect(70,130,120,5);
  fill(255,255,0);
  if(increA>=41)increA=41;
  if(increD>=41)increD=41;
  if(increH>=41)increH=41;
  rect(71,130,(118/41)*increA,4.5);
  fill(255);

  fill(0);
  textSize(12);
  text("DEF",70,225);
  fill(255);

  rect(70,230,120,5);
  fill(255,255,0);
  rect(71,230,(118/41)*increD,4.5);
  fill(255);
  fill(0);


  textSize(12);
  text("HP",70,325);
  fill(255);

  rect(70,330,120,5);
  fill(255,255,0);
  rect(71,330,(118/41)*increH,4.5);
  fill(255);



if(character.h>41) character.h=41;

if(character.h <0){
  character.h=0;
}
fill(255,0,0);
if( alive == true){
 // monster
  //rect(enemyX,enemyY,50,50); 
  image(monsterI, enemyX-4,enemyY-7,monsterI.width/3,monsterI.height/3);
} 

fill(0);
//ellipse(xpos, ypos, 40, 40); //character
image(characterI, xpos-30,ypos-50, characterI.width/4, characterI.height/4);
fill(255);
rect(xpos-20,ypos-60,43,6);
fill(0,255,0);
rect(xpos-19,ypos-59.5,character.h,5);


/*button=createButton("Attack");
button.position(66,510);
button.mousePressed(upgradeAt);

button=createButton("Health");
button.position(220,510);
button.mousePressed(upgradeH);

button=createButton("Armor");
button.position(220+220-66,510);
button.mousePressed(upgradeAr);

*/


if(nature.y1>=790){
  nature.y1 = 790;
}


if(key ==="a"){
  xpos -=7;
}
if(key==="d"){
  xpos +=7;
}
if(key==="w"&&gameStart==false){
  ypos -=7;
}
if(key ==="s"&&gameStart==false){
  ypos +=7;
}
if(key==="r"){
  alive = true;
  monster.h =30;
}
if(monster.h<0){
  monster.h=0;
}
if(xpos>=enemyX-greater &&xpos<=enemyX+smaller &&ypos>= enemyY-greater &&ypos<=enemyY+smaller){
  if(frameCount%60 ==0 && monster.h >0){
    character.h -= monster.at*(1-0.01*character.ar);
    increH=character.h;

  }
}
if(nature.y1 >=790||character.h<=0) {

  if(score==highScore &&score>0){
    if(gameStart==true) newRecord();
  }
  else 
  if(gameStart ==true) gameOver();
  }


  if(buttonStart==1){
    button2 = createButton("Reset");
  button2.position(pracX,pracY+80);
  button2.mousePressed(resetPracH);

  attackButton = createButton("+");
  attackButton.position(200,125);
  attackButton.mousePressed(upgradeAt);

  armorButton = createButton("+");
  armorButton.position(200,225);
  armorButton.mousePressed(upgradeAr);

  healthButton = createButton("+");
  healthButton.position(200,325);
  healthButton.mousePressed(upgradeH);

  gameRule = createButton("How To Play");
  gameRule.position(280,80);
  gameRule.mousePressed(rules);

  downH = createButton("-");
  downH.position(40,325);
  downH.mousePressed(downgradeH);
  
  downAt = createButton("-");
  downAt.position(40,125);
  downAt.mousePressed(downgradeAt);

  downAr = createButton("-");
  downAr.position(40,225);
  downAr.mousePressed(downgradeAr);

  atkbuttonC = createButton("++");
  atkbuttonC.position(200,155);
  atkbuttonC.mousePressed(coinUpgradeA);

  defbuttonC = createButton("++");
  defbuttonC.position(200,255);
  defbuttonC.mousePressed(coinUpgradeD);

  hpbuttonC= createButton("++");
  hpbuttonC.position(200,355);
  hpbuttonC.mousePressed(coinUpgradeH);

  downAtC = createButton("--");
  downAtC.position(40,155);
  downAtC.mousePressed(coinDowngradeA);

  downAtD = createButton("--");
  downAtD.position(40,255);
  downAtD.mousePressed(coinDowngradeD);

  downAtH = createButton("--");
  downAtH.position(40,355);
  downAtH.mousePressed(coinDowngradeH);
  buttonStart =3;
  }
  if(started ==0){
    starting();
  }
  if(howto==1) howtoplay();
  if(rule1==1) gamerules();
}






function keyPressed(){

  if(key===" " && xpos>=enemyX-greater &&xpos<=enemyX+smaller){

    monster.h -= character.at *(1-monster.ar*0.01);
    if(musicMute==false) sword.play();
  
    if(monster.h<=0&&level==1){
      if(musicMute==false) monsterDead.play();
      alive =false;
      coins+=2;
      score+=10;
      count+=1;
      enemyX = random(700, 1350);
      alive=true;
      monster.h=30;
      if(highScore <=score) highScore=score;
      if(score %100==0&&score>0){
        nature.y1-=10;
        enemyY-=10;
        ypos-=10;
        doorY-=10;
      }
      if(score==200) {
        level+=1;
        score+=100; // bonus score
      }
      
    }

    if(monster.h<=0 &&level>=2){
      if(musicMute==false) monsterDead.play();
      updateMonster();
      alive =false;
      score+=10;
      count+=1;
      coins+=2;
      enemyX = random(700, 1350);
      alive=true;
      monster.h=40;
      if(highScore <=score) highScore=score;
      if(score %100==0&&score>0){
        nature.y1-=10;
        enemyY-=10;
        ypos-=10;
        doorY-=10;
      }
      if(score==200) {
        level+=1;
        score+=100; // bonus score
      }
      
    }
  } 

  if(gameStart==false &&key===" "&&xpos>=30&&xpos<=100&&ypos>=590&&ypos<=690){
    xpos =700;
    ypos = nature.y1-20;
    gameStart=true;
  }
  if(gameStart==true&& key===" "&&xpos>=doorX&&xpos<=doorX+70){
    xpos=66;
    ypos=720;
    gameStart =false;
  }

  if(key===" "&& xpos>=pracX-10&&xpos<=pracX+75&&ypos>=pracY-10){
    monster1.h -= character.at *(1-monster1.ar*0.01);
    if(monster1.h<=0) monster1.h=0;
  }
  
}

function newRecord(){
  fill(255);
  stroke(0);
  strokeWeight(20);
  rect(300,300,800,220);
  fill(51);
  strokeWeight(1);
  textSize(80);
  text("Congratulation!", 410, 390);
  textSize(30);
  text("New Record!",410,440);
  text("Your Score: "+score,410, 480);

  button=createButton("Try again");
  button.position(800,450);
  button.mousePressed(restart);
  noLoop();
}

function gameOver(){
  fill(255);
  stroke(0);
  strokeWeight(20);
  rect(300,300,800,220);
  fill(51);
  strokeWeight(1);
  textSize(80);
  text("Game Over", 410, 390);
  textSize(30);
  text("High score: "+highScore,410,440)
  text("Your Score: "+score,410, 480);
  noStroke();
  stroke(0);
  button=createButton("Try again");
  button.position(800,450);
  button.mousePressed(restart);
  noLoop();

}
function restart(){


  started=1;
  noStroke();
  stroke(0);
  enemyY=320;
  nature.y1=370;
  doorY=286;
  xpos=66;
  ypos = 720;
  increA=0;
  increD=0;
  increH=41;


  score=0;
  c_Armor=30; // 30% reduce the damage
  c_Health=41;
  c_Attack=5;

  character.h=41;
  character.at=5;
  character.ar=30;
  monster.h=30;
  gameStart=false;
  level =1;
  m_Armor=13;
  m_Health=30;
  m_Attack=5;
  button.remove();
  loop();
  draw();
}






function mousePressed(){


  if(started==0&&mouseX>=560&&mouseX<=890&&mouseY>=550&&mouseY<=620){
    
    if(howto==0){
      howto=1;
    }
    else if(howto!=0){
      howto=0;
    }

  }
  if(started==0&&mouseX>=560&&mouseX<=890&&mouseY>=420&&mouseY<=490){
    buttonStart=1;

    restart();
  }
  //rect(1200,15,50,50);
if(mouseX>=1200&&mouseX<=1250&&mouseY>=15&&mouseY<=65){
  if(musicMute==false){
    backgroundmusic.pause();
    
    
    musicMute=true;
    isOn=false;
  }
  else if(musicMute==true){
    backgroundmusic.play();
    
    musicMute=false;
    isOn=true;
  }
}
  

}


function upgradeAr(){
  if(gameStart==false&&character.ar<=110){
    numberD+=1;
    character.ar +=2;
    nature.y1+=10;
    enemyY+=10;
    doorY+=10;
    increD+=1;
  }

}

function upgradeAt(){
  if(gameStart==false&&character.at<=45){
    numberA+=1;
    character.at +=1;
    nature.y1+=10;
    doorY+=10;
    enemyY+=10;
    increA+=1;

  }

}

function upgradeH(){
  if(gameStart==false&&character.h<=40){
    numberH+=1;
    character.h +=1;
    nature.y1+=10;
    doorY+=10;
    enemyY+=10;
    increH+=1;
   
  }

}
function downgradeAt(){
  if(gameStart==false){
    if(character.at>=6&&numberA>=1){
      numberA-=1;
      character.at-=1;
      nature.y1-=10;
      enemyY-=10;
      increA-=1;
      doorY-=10;


    }
  }
}
function downgradeAr(){
  if(gameStart==false){
    if(character.ar>=32&&numberD>=1){
      numberD-=1;
      character.ar-=2;
      nature.y1-=10;
      doorY-=10;
      enemyY-=10;
      increD-=1;


    }
  }
}function downgradeH(){
  if(gameStart==false){
    if(character.h>=39&&numberH>=1){
      numberH-=1;
      doorY-=10;
      character.h-=1;
      nature.y1-=10;
      enemyY-=10;
      increH-=1;
      hp-=1;

    }
  }
}
function updateMonster(){
  m_Armor+=17;
  m_Health+=40;
  m_Attack+=8;
}
function resetPracH(){
  monster1.h =30;
}
function coinUpgradeA(){
  if(coins >=8){
    increA+=1;
    character.at+=1;
    countA+=1;
    coins-=8;

  }
}
function coinUpgradeD(){
  if(coins >=8){
    coins-=8;
    increD+=2;
    character.ar+=2;
    countD+=1;

  }
}function coinUpgradeH(){
  if(coins >=8&&character.h<=40){
    coins-=8;
    increH+=5;
    character.h+=5;
    countH+=1;
    
  }
}
function coinDowngradeA(){
  if(countA>=1){
    if(character.at>=6){
      countA -=1;
      character.at-=1;
      increA-=1;
      coins+=8;
    }

  }
}
function coinDowngradeD(){
  if(countD>=1){
    if(character.ar>=32){
      countD-=1;
      increD-=2;
      character.ar-=2;
      coins+=8;
    }
  
  }
}function coinDowngradeH(){
  if(countH>=1){
    if(character.h>=0){

      countH-=1;
      increH-=5;
      character.h-=5;
      coins+=8;
    }
  
  }
}
function starting(){

  background(backgroundphoto);
//1440 790
  textSize(130);
  fill(30,30,130);
  text("Iceberg",360,150);
  fill(30,30,100);
  text("   Challenge",360,300);

  noStroke();
  fill(30,30,80,190);

  fill(255,150);
  textFont('Helvetica');

  textSize(50);  
  fill(30,30,160);
  image(ice, 805,85,70,70);
  image(icestart,550,400,350,100);
  text("Play",630,470);
  textSize(30);  

  image(icestart,550,530,350,100);
  text("How To Play",595,595);

  //fill(255,100);
  //rect(560,550,230,70);

}
function howtoplay(){


  textFont('Bradley Hand');

  image(icestart,490,0,600,700);
  textSize(20);
  fill(0,0,20);
  text("1. Move your character using w,a,s,d",540,200);
  fill(10,10,100);
  text("2. Hit spacebar to kill garbage monsters",540,240);
  fill(0,0,150);
  text("3. You can upgrade your abilities ",540,280);
  text("    with the button '+' that decreases",540,300);
  text("    the level of iceberg",540,320);
  fill(0,0,200);
  text("4. You will gain 2 coins when a",540,360);
  text("    monster is killed",540,380);
  fill(100,100,255);

  text("5. You can upgrade your abilities with",540,420);
  text("   the button '++' that Doesn't decrease",540,440);
  text("   the level of iceberg using 8 coins",540,460);
  fill(150,150,200);
  text("6. You can enter the field or the room",540, 490);
  text("    through the door with spacebar",540, 510);
  fill(255);
  text("7. The iceberg is sinking every second!",540,540);

  
  image(tick, 670,560,50,50);

}
function rules(){
  if(rule1 ==0){
    rule1=1;
  }else if(rule1==1){
    rule1=0;
  }
}
function gamerules(){

  fill(255,30);
  noStroke();
  rect(280,100,250,300);

  textSize(13);
  fill(0,0,20);
  text("1. Move your character using w,a,s,d",290,120);
  fill(10,10,100);
  text("2. Hit spacebar to kill garbage monsters",290,150);
  fill(0,0,150);
  text("3. You can upgrade your abilities ",290,170);
  text("   with the button '+' that decreases",290,190);
  text("   the level of iceberg",290,210);
  fill(0,0,200);
  text("4. You will gain 2 coins when a",290,240);
  text("    monster is killed",290,260);
  fill(0,0,230);

  text("5. You can upgrade your abilities with",290,290);
  text("    the button '++' that Doesn't decrease",290,310);
  text("    the level of iceberg using 8 coins",290,330);
  fill(0,0,255);

  text("6. The iceberg is sinking every second!",290,360);

  

}


