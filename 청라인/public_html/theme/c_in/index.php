<?php
define('_INDEX_', true);
if (!defined('_GNUBOARD_')) exit; // 개별 페이지 접근 불가

if (G5_IS_MOBILE) {
    include_once(G5_THEME_MOBILE_PATH.'/index.php');
    return;
}

include_once(G5_THEME_PATH.'/head.php');

?>
<script>
	$("#top-close").click(function() {
		$(".banner-background").hide();
	});
	</script>
	<style>
	    @font-face {
    
    src: url('https://cdn.jsdelivr.net/gh/projectnoonnu/noonfonts_2302@1.1/Dovemayo_gothic.woff2') format('woff2');
    font-weight: normal;
    font-style: normal;
}
body {
    /**/
    font-family: 'Noto Sans KR', sans-serif;
}
            #pc_b{
	            display:block;
	        }
	        #mobile_b{
	            display:none;
	        }
	    @media (max-width:800px){
	        #pc_b{
	            display:none;
	        }
	        #mobile_b{
	            display:block;
	        }
	    }
	    
	</style>
<!-- 슬라이드 -->



<style>

    .containers {
        margin-top:1%;
        display:grid;
        width:100%;
        grid-template-columns: repeat(4, 1fr);
        text-align:center;
        gap: 1%;
        height:80px;
    }
    
    .items {
        width:100%;
        text-align:center;
        cursor: pointer;
        position: relative;
    box-shadow: 5px 5px 8px rgb(50 60 70 / 10%);
    -webkit-box-shadow: 5px 5px 8px rgb(50 60 70 / 10%);
    -moz-box-shadow: 5px 5px 8px rgb(50 60 70 / 10%);
    background: #fff;
    overflow: hidden;
    border-radius: 10px;
    }
    .items_1 {
        width:100%;
        text-align:center;
        line-height: 80px;
        
    }
    .items_1 img{
        width:23%;
    }
    .items_1 span{
        font-size:20px;
    }
    #kakao {
        font-weight:bold;
        
    }
    @media (max-width:600px){
        .containers {
        margin-top:3%;
        display:grid;
        width:100%;
        grid-template-columns: repeat(2, 1fr);
        text-align:center;
        gap: 6% 2%;
        height:100px;
    }
    .items_1 {
        width:100%;
        text-align:center;
        line-height: 45px;
        
    }
    #kakao {
        font-size:15px;
        font-weight:bold;
        
    }
    
    }

    
</style>

<div class="containers">
    <div class="items" onclick="location.href='/bbs/board.php?bo_table=store'" style="background: #FF9ED0;">
        <div class="items_1">
            <img src="/img/store.png">
        <span id="kakao">단골 가게</span>
        </div>
        
    </div>
    <div class="items" onclick="location.href='/bbs/board.php?bo_table=reviews_2'" style="background: #95FFA6;">
        <div class="items_1">
            <img src="/img/gather.png">
        <span id="kakao">프리미엄 리뷰</span>
        </div>
    </div>
    <div class="items" onclick="location.href='/bbs/board.php?bo_table=sale'" style="background: #95F7FF;">
        <div class="items_1">
            <img src="/img/sale.png">
        <span id="kakao">청라 할인 정보</span>
        </div>
    </div>
    <div class="items" onclick="window.open('http://pf.kakao.com/_Txexkxmxj')" style="background: #F7E600;">
        <div class="items_1" >
            <img src="/img/kakao.png">
        <span style="color:#3A1D1D;font-size:15px;"id="kakao">카카오톡 고객센터</span>
        </div>
    </div>
    
    
</div>






<!-------------------------- 커뮤니티 -------------------------->
<div class="head-title-2"style="">
	<h2 class="h2-title-bottom" style="">최신 글</h2>
	<a href="#" class="btn-more"><span class="sound_only" style="">최신 글</span></a>
</div>
<div class="row">
	<div class="col-md-12">
			<!-- tab menu -->
		  <ul class="nav nav-tabs nav-justified" role="tablist">
			<li class="nav-item">
			  <a class="nav-link active" data-toggle="tab" href="#t1">청라 새소식</a>
			</li>
			<li class="nav-item">
			  <a class="nav-link" data-toggle="tab" href="#t2">자유 게시판</a>
			</li>
			<li class="nav-item">
			  <a class="nav-link" data-toggle="tab" href="#t3">일반 리뷰</a>
			</li>
		  </ul>
		  <!-- Tab panes -->
		  <div class="tab-content" style="    background: #fff;
    -webkit-box-shadow: 0 1px 2px rgb(0 0 0 / 10%);
    -moz-box-shadow: 0 1px 2px rgba(0,0,0,0.1);
    box-shadow: 5px 5px 8px rgb(50 60 70 / 10%), -3px -3px 6px #fff;
    border-radius: 0 0 10px 10px;padding: 10px;">
			<div id="t1" class="tab-pane active"><br>
				<div class="row">
					<div class="col-md-12"><?php echo latest_options('theme/sub_text_1', 'news', 12, 15);?></div>
				</div>
			</div>
			<div id="t2" class="tab-pane fade"><br>
				<div class="row">
					<div class="col-md-12"><?php echo latest('theme/sub_text_1', 'free', 12, 15);?></div>
				</div>
			</div>
			<div id="t3" class="tab-pane fade"><br>
				<div class="row">
					<div class="col-md-12"><?php echo latest('theme/sub_text_1', 'reviews_1', 12, 15);?></div>
				</div>
			</div>
		  </div>
	</div><!-- /col -->
</div><!-- /row -->




<div class="row" style="margin-top:3%">
	<div class="col-md-12">
			<!-- tab menu -->
		  <ul class="nav nav-tabs nav-justified" role="tablist">
			<li class="nav-item">
			  <a class="nav-link active" data-toggle="tab" href="#t4">공지사항</a>
			</li>
			<li class="nav-item">
			  <a class="nav-link" data-toggle="tab" href="#t5">이벤트</a>
			</li>
			<li class="nav-item">
			  <a class="nav-link" data-toggle="tab" href="#t6">유머 게시판</a>
			</li>
			
		  </ul>
		  <!-- Tab panes -->
		  <div class="tab-content" style="    background: #fff;
    -webkit-box-shadow: 0 1px 2px rgb(0 0 0 / 10%);
    -moz-box-shadow: 0 1px 2px rgba(0,0,0,0.1);
    box-shadow: 5px 5px 8px rgb(50 60 70 / 10%), -3px -3px 6px #fff;
    border-radius: 0 0 10px 10px;padding: 10px;">
			<div id="t4" class="tab-pane active"><br>
				<div class="row">
					<div class="col-md-12"><?php echo latest_options('theme/sub_text_1', 'notice', 12, 23);?></div>
				</div>
			</div>
			<div id="t5" class="tab-pane fade"><br>
				<div class="row">
					<div class="col-md-12"><?php echo latest('theme/sub_text_1', 'event1', 12, 23);?></div>
				</div>
			</div>
			<div id="t6" class="tab-pane fade"><br>
				<div class="row">
					<div class="col-md-12"><?php echo latest('theme/sub_text_1', 'humor', 12, 23);?></div>
				</div>
			</div>
			
		  </div>
	</div><!-- /col -->
</div><!-- /row -->



    <div class="head-title-2"style="">
	<h2 class="h2-title-bottom" style="">사진방</h2>
	<a href="#" class="btn-more"><span class="sound_only" style="">사진방</span></a>
</div>
    
    <?php echo latest('theme/sub_gallery_3', 'gallery', 8, 23);?>






<!-------------------------- ./분류 끝 -------------------------->




<!-- 갤러리 슬라이드 -->
<!--<div class="ht10"></div> -->

<!--<div style="box-shadow: 5px 5px 8px rgb(50 60 70 / 10%);-->
<!--    -webkit-box-shadow: 5px 5px 8px rgb(50 60 70 / 10%);-->
<!--    -moz-box-shadow: 5px 5px 8px rgb(50 60 70 / 10%);-->
<!--    background: #fff;-->
<!--    overflow: hidden;-->
<!--    border-radius: 10px; width:100%; margin-top:3%">-->
    
<!--    <img src="/img/banner2.png" style="width: 100%;">-->
<!--</div>-->




<div class="ht50"></div>

<?php
include_once(G5_THEME_PATH.'/tail.php');
?>