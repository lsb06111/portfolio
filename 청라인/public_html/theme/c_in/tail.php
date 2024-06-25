<?php
if (!defined('_GNUBOARD_')) exit; // 개별 페이지 접근 불가

if (G5_IS_MOBILE) {
    include_once(G5_THEME_MOBILE_PATH.'/tail.php');
    return;
}
?>
	</div><!-- /col -->
	<div class="col-md-3 layout-right pb30 pt20 pc">
			<?php
			// 이 함수가 바로 최신글을 추출하는 역할을 합니다.
			// 사용방법 : latest(스킨, 게시판아이디, 출력라인, 글자수);
			// 테마의 스킨을 사용하려면 theme/basic 과 같이 지정
			?>
			<?php echo outlogin('theme/basic_v10'); // 외부 로그인, 테마의 스킨을 사용하려면 스킨을 theme/basic 과 같이 지정 ?>
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




<u-chat id="mob_chat" room='<?php echo $joinData['room'];?>' user_data='<?php echo uchat_array2data($joinData); ?>' style="margin-top:5%;display:inline-block; width:100%; height:400px;background: #fff;box-shadow: 5px 5px 8px rgb(50 60 70 / 10%), -3px -3px 6px #fff;border-radius: 10px;">
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




			<? if($bo_table){ ?>
			<!-- 해당그룹 카테고리 출력 -->
			<div class="head-title">
				<h2 class="h2-title-bottom">카테고리</h2>
				<a href="#" class="btn-more"><span class="sound_only">카테고리</span></a>
			</div>
			<?php
				$sql = "select * from g5_board where gr_id = '".$gr_id."'";
				$result = sql_query($sql);
				while($row = sql_fetch_array($result)){
					if($row['bo_table'] == $_GET['bo_table']) {
						$active = "on";
						echo "<a href='/bbs/board.php?bo_table=".$row['bo_table']."'>";
						echo "<div class='left_menu ".$active."'>".$row['bo_subject']."</div>";
						echo "</a>";
					}else{
						$active = "";
						echo "<a href='/bbs/board.php?bo_table=".$row['bo_table']."'>";
						echo "<div class='left_menu ".$active."'><img src='".G5_THEME_URL."/img/icon_list.png'> &nbsp;".$row['bo_subject']."</div>";
						echo "</a>";
					}
					//echo "<a href='/bbs/board.php?bo_table=".$row['bo_table']."'>";
					//echo "<div class='left_menu ".$active."'><img src='".G5_THEME_URL."/img/icon_list.png'> &nbsp;".$row['bo_subject']."</div>";
					//echo "</a>";
				}
			}
			?>
			<!-- /해당그룹 카테고리 출력 -->		

			
			<?php
			// 메인페이지에서만 출력합니다.
			if(!$bo_table) {
			?>

			<!-- 새글,새댓글 -->
			<div class="ht20"></div>


			<div class="row" style="margin-top:3%">
				<div class="col-md-12">
					  <ul class="nav nav-tabs nav-justified" role="tablist">
						<li class="nav-item">
						  <a class="nav-link active" data-toggle="tab" href="#lb1">리뷰</a>
						</li>
						<li class="nav-item">
						  <a class="nav-link" data-toggle="tab" href="#lb2">플리 마켓</a>
						</li>
					  </ul>
					  <!-- Tab panes -->
					  <div class="tab-content" style="    background: #fff;
    -webkit-box-shadow: 0 1px 2px rgb(0 0 0 / 10%);
    -moz-box-shadow: 0 1px 2px rgba(0,0,0,0.1);
    box-shadow: 5px 5px 8px rgb(50 60 70 / 10%), -3px -3px 6px #fff;
    border-radius: 0 0 10px 10px;padding: 10px;">
						<div id="lb1" class="tab-pane active">
							<div class="row">
								<!-- 서브갤러리 -->
								<div class="col-md-12">
									<?php echo latest('theme/basic', 'reviews_1', 10, 10);?>
									
								</div>
							</div>
						</div>
						<div id="lb2" class="tab-pane fade">
							<div class="row">
								<!-- 서브갤러리 --><div class="col-md-12"><?php echo latest('theme/basic', 'flee1', 10, 10);?></div>
							</div>
						</div>
					  </div><!-- /tab -->
				</div><!-- /col -->
			</div><!-- /row -->
			
			
			<?php echo poll('theme/basic_v10'); // 설문조사, 테마의 스킨을 사용하려면 스킨을 theme/basic 과 같이 지정 ?>
			<?php echo visit('theme/basic_v10'); // 접속자집계, 테마의 스킨을 사용하려면 스킨을 theme/basic 과 같이 지정 ?>
		<?php }// 메인페이지 if?>

		</div>
	</div><!-- /row -->
</div><!-- /container -->


<footer class="bg-light">
	<div class="container">
	<div class="row">

		<div class="col-md-3 pt20 pb20 footer_1">
			<!-- 로고 -->
			<img src="/img/logo.png" class="logo_img mb20" alt="<?php echo G5_VERSION ?>">
			<p class="pcontent">
			청라의 모든것, 청라in
			</p>
			<p class="pcontent">
			청라 사람들의 삶의 질 향상을 위해 저희<br />
			청라in은 다양한 서비스를 제공하려 합니다. <br />
			많은 관심 부탁드립니다 ^_^
			</p>
		</div>

		<div class="col-md-3 pt20 pb80 footer_2">
			<div class="footer_title">인기검색어</div>
			<!-- 인기검색어 -->
			<?php echo popular('theme/basic_v10','15'); // 인기검색어?>
			<!--<div class="footer_title mt20">SNS</div>-->
		</div>

		<div class="col-md-3 pt20 pb20 footer_3">
			<div class="footer_title">바로가기</div>
			<ul class="list-link list-dep">
				<li><a href="/bbs/board.php?bo_table=news">청라 새소식</a><i class="fa fa-angle-right"></i></li>
				<li><a href="/bbs/board.php?bo_table=notice">공지사항</a><i class="fa fa-angle-right"></i></li>
				<li><a href="/bbs/board.php?bo_table=free">자유게시판</a><i class="fa fa-angle-right"></i></li>
				<li><a href="/bbs/board.php?bo_table=flee1">플리마켓</a><i class="fa fa-angle-right"></i></li>
				<li><a href="/bbs/board.php?bo_table=gather">청라 모임</a><i class="fa fa-angle-right"></i></li>
			</ul>
		</div>

		<div class="col-md-3 pt20 pb20 footer_4">
			<div class="footer_title">영업시간, 사업자 정보</div>
			<!-- 영업시간안내 -->
			<p class="m-0 a-link pb10 pcontent">
			영업시간안내 : 09:00 ~ 23:00<br />
			
			</p>
			
			<!-- 주소 -->
			<strong>[사업자 정보]</strong><br>
			<p class="m-0 a-link pcontent">
			상호명: 앱퍼(Apper)<br />
			사업자번호: 291-21-01333<br />
			대표자: 이수빈<br />
			연락처 : <strong>010-2501-4073</strong><br />
			주소: 인천광역시 서구 청라에메랄드로 112, 222동 2402호<br />
			Email : cheongnain647@gmail.com
			
			</P>
			
			<!-- SNS -->
			<p class="m-0 a-link">

			</p>
		</div>

		<div class="col-md-12 mt20 mb50 text-center">
			<div id="ft_wr">
				<div id="ft_link">
					Copyright &copy; <b>청라in.</b> All rights reserved.
					<!--<a href="<?php echo G5_BBS_URL; ?>/content.php?co_id=company">회사소개</a>-->
					<!--<a href="<?php echo G5_BBS_URL; ?>/content.php?co_id=privacy">개인정보처리방침</a>-->
					<!--<a href="<?php echo G5_BBS_URL; ?>/content.php?co_id=provision">서비스이용약관</a>-->
				</div>
			</div>
		</div>
	</div>





	
	
	<button type="button" class="talk_button" id="top_btn" style="bottom:75px;background: linear-gradient(120deg, #4880FF 28%, #3D66E7 23%);border:none;"><p style="line-height: 25px; color:white;">실시간<br>채팅</p></i><span class="sound_only">실시간 채팅</span></button>
<style>
        .talk_button{
            display:none;
        }
        
	    @media (max-width:800px) {
	        .talk_button {
	            display:block;
	        }
	        
	    }
	</style>
	<button type="button" class="top_btn" id="top_btn"><i class="fa fa-arrow-up" aria-hidden="true"></i><span class="sound_only">상단으로</span></button>
	<script>
	$(function() {
		$(".top_btn").on("click", function() {
			$("html, body").animate({scrollTop:0}, '500');
			return false;
		});
	});
	
	$(function() {
		$(".talk_button").on("click", function() {
			location.href="/bbs/content.php?co_id=live_chat";
			
		});
	});
	
	
	
	
	
	</script>
	</div><!-- //container -->
</footer>
<?php
if(G5_DEVICE_BUTTON_DISPLAY && !G5_IS_MOBILE) { ?>
<?php
}

if ($config['cf_analytics']) {
    echo $config['cf_analytics'];
}
?>

<!-- } 하단 끝 -->

<script>
$(function() {
    // 폰트 리사이즈 쿠키있으면 실행
    font_resize("container", get_cookie("ck_font_resize_rmv_class"), get_cookie("ck_font_resize_add_class"));
});
</script>



    <!-- Bootstrap core JavaScript -->
    <!--<script src="vendor/jquery/jquery.min.js"></script>-->
	<script type="text/javascript" src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
	<script>
	var jQuery = $.noConflict(true);
	</script>
    <script src="<?php echo G5_THEME_URL?>/assets/bootstrap/js/bootstrap.bundle.min.js"></script>
	<script src="<?php echo G5_THEME_URL?>/assets/parallax/js/parallax.min.js"></script>
	<script src="<?php echo G5_THEME_URL?>/assets/owlcarousel/js/owl.carousel.min.js"></script>

	<!-- countdown -->
	<script type="text/javascript" src="<?php echo G5_THEME_URL?>/assets/countdown/js/kinetic.js"></script>
	<script type="text/javascript" src="<?php echo G5_THEME_URL?>/assets/countdown/js/jquery.final-countdown.js"></script>
	<!-- custom -->
	<script src="<?php echo G5_THEME_URL?>/js/custom.js"></script>
	<script src="<?php echo G5_THEME_URL?>/js/bootstrap-essentials.js"></script>
	<script>
	$(window).resize(function (){
		var windowWidth = window.outerWidth;
		if (windowWidth <= 990) {
			$(".main-container").removeClass('col-md-9');
			$(".main-container").addClass('col-md-12');
		}else{
			$(".main-container").removeClass('col-md-12');
			$(".main-container").addClass('col-md-9');
		}
	});

	// <![CDATA[
	jQuery(function($){
		$("ul.gnb > li").mouseover(function(){
			$(".gnbDepth").hide();
			$(".gnbDepth",this).show();
		});
		$("ul.gnb").mouseover(function(e){
			if(e.target==this) $(".gnbDepth").hide();
		});
		$("ul.gnb > li .gnbDepth").mouseout(function(){
			$(this).hide();
		});
		$("article").mouseout(function(){
			$("ul.gnb > li .gnbDepth").hide();
		});
		$(window).on('scroll', function() {
			if($(window).scrollTop() > 0) $('body > div.btn-top').show();
			else $('body > div.btn-top').hide();
		});
	});
	// ]]>

	</script>

<?php
include_once(G5_THEME_PATH."/tail.sub.php");
?>