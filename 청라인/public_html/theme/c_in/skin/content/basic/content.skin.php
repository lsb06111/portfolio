<?php
if (!defined('_GNUBOARD_')) exit; // 개별 페이지 접근 불가

// add_stylesheet('css 구문', 출력순서); 숫자가 작을 수록 먼저 출력됨
add_stylesheet('<link rel="stylesheet" href="'.$content_skin_url.'/style.css">', 0);
?>

<article id="ctt" class="ctt_<?php echo $co_id; ?>">
    <header>
        <h1><?php echo $g5['title']; ?></h1>
    </header>

    <?php if($co_id == 'live_chat'){?>
    <?php
include_once("_common.php");

if(!function_exists('uchat_array2data')) {
	function uchat_array2data($arr) {
		$arr['time'] = time();
		ksort($arr);
		$arr = array_filter($arr);
		$arr['hash'] = md5(implode($arr['token'], $arr));
		unset($arr['token']);
		foreach ($arr as $k => &$v){ $v = $k.' '.urlencode($v); }
		return implode("|", $arr);
	}
}
$joinData = array();
$joinData['room'] = 'che_in';
/////////////////////////////////////////
// !!!!!!!!!!!!!!!!절대 유출 금지!!!!!!!!!!!!!!
// 아래 token 이 유출되면 이 채팅방의 모든 권한을 얻을 수 있습니다.
////////////////////////////////////////
$joinData['token'] = 'bdf8c38f22d9383d61e7024281aaf8df'; //!!!!!!!!!!!!!!!!절대 유출 금지!!!!!!!!!!!!!!

$joinData['nick'] = $member['mb_nick'];
$joinData['id'] = $member['mb_id'];
$joinData['level'] = $member['mb_level'];
$joinData['auth'] = $is_admin?"admin":"";
if($is_member) {
	$uicon_file = "/data/member/".substr($member['mb_id'],0,2)."/".$member['mb_id'].".gif";
	if(file_exists((G5_PATH?G5_PATH:$g4['path']).$uicon_file))
		$joinData['icons'] = $uicon_file;
}
//$joinData['nickcon'] = '';
//$joinData['other'] = '';
?>


<script async src="//client.uchat.io/uchat.js"></script>




<u-chat id="mob_chat" room='<?php echo $joinData['room'];?>' user_data='<?php echo uchat_array2data($joinData); ?>' style="display:inline-block; width:100%; height:500px;background: #fff;box-shadow: 5px 5px 8px rgb(50 60 70 / 10%), -3px -3px 6px #fff;border-radius: 10px;">
    <script>U=window.U=window.U||{},U.events=U.events||[],U.chat=function(n){return{on:function(e,t){U.events.push([n,e,t])},off:function(e){for(var t=U.events.length;t>0;)U.events[--t][0]==n&&U.events[t][1]==e&&U.events.splice(t,1)}}};</script>


</u-chat>

<script type="text/template" id="Uchat_custom_style">
    <style>
//     @font-face {
//     font-family: 'Dovemayo_gothic';
//     src: url('https://cdn.jsdelivr.net/gh/projectnoonnu/noonfonts_2302@1.1/Dovemayo_gothic.woff2') format('woff2');
//     font-weight: normal;
//     font-style: normal;
// }
// body {
//     font-family: 'Dovemayo_gothic';
//     font-size:105%
// }
        .wrap {border:none;border-radius:10px;}
        .top{
            background: linear-gradient(120deg, #4880FF 28%, #3D66E7 23%);
        }
        .top .chatname{
            color:white;
        }
    </style>
</script>
<script>
U.chat('*').on('after.create', function (room, data) {
    var $ = room.skin.window.$; // 스킨 내부의 jquery 가져오기
    $('head').append($('#Uchat_custom_style', document).html()); // css 설치
});
</script>
    
    
    
    <?php }else {?>
    <div id="ctt_con">
        <?php echo $str; ?>
    </div>
    
    <?php }?>

</article>