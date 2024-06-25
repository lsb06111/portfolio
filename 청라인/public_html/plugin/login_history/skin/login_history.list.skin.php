<?php
if (!defined('_GNUBOARD_')) exit; // 개별 페이지 접근 불가

auth_check_menu($auth, $this->admin_number, 'r');
?>
<style>
.anchor li a.selected {color:#fff}
.tbl_head01.tbl_wrap td.user_agent {font-size:0.9em}
</style>
<ul class="anchor">
<li><a href="<?php echo get_params_merge_url(array('ltype'=>'')); ?>" class="<?php echo (! $ltype ? 'selected' : ''); ?>" >전체보기</a></li>
<li><a href="<?php echo get_params_merge_url(array('ltype'=>'fail')); ?>" class="<?php echo ($ltype === 'fail' ? 'selected' : ''); ?>" >로그인실패만 보기</a></li>
<li><a href="<?php echo get_params_merge_url(array('ltype'=>'success')); ?>" class="<?php echo ($ltype === 'success' ? 'selected' : ''); ?>" >로그인성공만 보기</a></li>
</ul>

<form id="fsearch" name="fsearch" class="local_sch01 local_sch" method="get">
    <input type="hidden" name="call" value="<?php echo $call; ?>">
    <input type="hidden" name="ltype" value="<?php echo $ltype; ?>">

    <label for="sfl" class="sound_only">검색대상</label>
    <select name="sfl" id="sfl">
        <!-- <option value="" <?php echo get_selected($sfl, ""); ?>>선택하기</option> -->
        <option value="login_id" <?php echo get_selected($sfl, "login_id"); ?>>아이디</option>
        <option value="user_ip" <?php echo get_selected($sfl, "user_ip"); ?>>아이피</option>
        <option value="user_agent" <?php echo get_selected($sfl, "user_agent"); ?>>사용자환경</option>
    </select>
    <label for="stx" class="sound_only">검색어<strong class="sound_only"> 필수</strong></label>
    <input type="text" name="stx" value="<?php echo $stx ?>" id="stx" required class="required frm_input">
    <input type="submit" class="btn_submit" value="검색">

</form>

<div class="tbl_head01 tbl_wrap">
    <table>
        <thead>
            <tr>
                <th>구분</th> 
                <th>아이디</th>
                <th>아이피</th>
                <th>사용자환경</th>
                <th>기록시간</th>
            </tr>
        </thead>
        <tbody>
        <?php
        foreach($list as $key=>$row){
            $str_type = "접속기록";
            
            if ($row['login_type'] === 'fail') {
                $str_type = "로그인실패";
            }

            if( $sfl === 'login_id' && $stx ){
                $row['login_id'] = search_font($stx, $row['login_id']);
            } else if( $sfl === 'user_ip' && $stx ){
                $row['user_ip'] = search_font($stx, $row['user_ip']);
            } else if( $sfl === 'user_agent' && $stx ){
                $row['user_agent'] = search_font($stx, $row['user_agent']);
            }
        ?>
            <tr>
                <td><?php echo $str_type; ?></td>
                <td><?php echo $row['login_id']; ?></td>
                <td><?php echo $row['user_ip']; ?></td>
                <td class="user_agent"><?php echo $row['user_agent']; ?></td>
                <td><?php echo $row['history_datetime']; ?></td>
            </tr>
        <?php } // end for ?>
        </tbody>
    </table>

    <?php echo get_paging(G5_IS_MOBILE ? $config['cf_mobile_pages'] : $config['cf_write_pages'], $page, $total_page, '?' . $qstr . '&amp;page='); ?>

</div>