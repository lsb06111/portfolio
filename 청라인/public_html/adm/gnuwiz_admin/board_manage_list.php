<?php
$sub_menu = "600400";
require_once './_common.php';
require_once './board_manage_list.class.php';

auth_check_menu($auth, $sub_menu, 'r');

if ($is_admin != 'super') {
    alert('최고관리자만 접근 가능합니다.');
}

$bo_table = isset($_GET['bo_table']) ? $_GET['bo_table'] : null;

// 인스턴스 생성
$board_manage_list = new BOARD_MANAGE_LIST();

// 게시판 목록
$board_list = $board_manage_list->get_board_list();

// bo_table 설정
if($bo_table) {
    $board_manage_list->set_bo_table($bo_table);
}

// 페이지 설정
$rows = $config['cf_page_rows'];
if ($page < 1) {
    $page = 1; // 페이지가 없으면 첫 페이지 (1 페이지)
}
$from_record = ($page - 1) * $rows; // 시작 열을 구함

// 리스트 만들기
$board_manage_list->rows		= $rows;
$board_manage_list->page		= $page;
$board_manage_list->from_record	= $from_record;
//$board_manage_list->sst	= "wr_datetime"; // 정렬필드
//$board_manage_list->sod	= "desc"; // 차순정렬

unset($opt);
if (isset($s_wr_id)) {
    $opt['s_wr_id'] = $s_wr_id;
}
if (isset($s_wr_subject)) {
    $opt['s_wr_subject'] = $s_wr_subject;
}
$opt['simple_wr_content'] = 1; // 태그 없애도 짧게 잘라서 리턴함
$list = $board_manage_list->lists($opt);

// 페이지
$total_count = $list['total_count'];
$total_page = $list['total_page'];

$listall = '<a href="' . $_SERVER['SCRIPT_NAME'] . '" class="ov_listall">전체목록</a>';

$g5['title'] = '게시글 날짜&조회수';
require_once G5_ADMIN_PATH.'/admin.head.php';

$colspan = 8;
?>

<style>
.tbl_wrap input[type=text] { width:110px; border:1px solid #AAA; padding:2px; text-align: center; }
.tbl_wrap select { padding:5px; }
.tbl_wrap tr:hover td { background: #F6F6F6; }
.gray {font-size:10px;color:gray;}
</style>

<div class="local_ov01 local_ov">
    <?php echo $listall ?>
    <span class="btn_ov01"><span class="ov_txt">Total</span><span class="ov_num"> <?php echo number_format($total_count) ?>개</span></span>
    <span class="btn_ov01"><span class="ov_txt">페이지</span><span class="ov_num"> <?php echo number_format($total_page) ?></span></span>
</div>

<form name="fsearch" id="fsearch" class="local_sch03  local_sch" method="get">
    <div>
        <label for="bo_table" class=""><strong>게시판 선택</strong></label>
        <?php echo get_board_select("bo_table", $bo_table, "","");?>
    </div>
    <div>
        <label for="s_wr_id" class=""><strong>고유번호</strong></label>
        <input type="text" name="s_wr_id" value="<?php echo $s_wr_id ?>" id="s_wr_id" class="frm_input">
    </div>
    <div>
        <label for="s_wr_subject" class=""><strong>제목</strong></label>
        <input type="text" name="s_wr_subject" value="<?php echo $s_wr_subject ?>" id="s_wr_subject" class="frm_input">
        <input type="submit" value="검색" class="btn_submit">
    </div>
</form>

<form name="fconfigform" id="fconfigform" method="post" onsubmit="return fconfigform_submit(this);">
    <input type="hidden" name="token" value="">

    <div class="tbl_head01 tbl_wrap">
        <table>
            <caption><?php echo $g5['title']; ?> 목록</caption>
            <thead>
            <tr>
                <th scope="col">고유번호</th>
                <th scope="col">게시판</th>
                <th scope="col">분류</th>
                <th scope="col">제목</th>
                <th scope="col">등록일</th>
                <th scope="col">최종수정일</th>
                <th scope="col">조회수</th>
                <th scope="col">관리</th>
            </tr>
            </thead>
            <tbody>
            <?php
            if($list['list']) {
                foreach($list['list'] as $k => $v) {
                    $no = $list['total_count'] - ($page - 1) * $rows - $k;

                    $wr_comment = false;
                    if ($v['wr_is_comment']) {
                        $wr_comment = true;
                    }

                    $v_mod = '<a href="'.G5_BBS_URL.'/board.php?bo_table=' . $v['bo_table'] . '&amp;wr_id=' . $v['wr_id'] . '" class="btn btn_01" target="_blank">보기</a>';
                    $u_mod = '<button type="button" class="btn btn_03" onclick="update(\''.$v['bo_table'].'\', \''.$v['wr_id'].'\', \''.$wr_comment.'\')">수정</button>';

                    $bg = 'bg'.($k%2);
                    ?>

                    <tr class="<?php echo $bg; ?>">
                        <td class="td_cnt">
                            <a href="<?php echo G5_BBS_URL?>/board.php?bo_table=<?php echo $v['bo_table']?>&wr_id=<?php echo $v['wr_id']?>" target="_blank" style="color:blue;">
                                <?php echo $v['wr_id']?>
                            </a>
                        </td>
                        <td class="td_id"><?php echo $v['bo_table']?></td>
                        <td class="td_id"><?php echo $v['ca_name']?></td>
                        <td class="td_left">
                            <?php
                            if($v['wr_reply']){
                                for($i=0;$i<strlen($v['wr_reply']);$i++) {
                                    echo "<span class='gray'>[답변]</span>";
                                }
                            }
                            ?>
                            <?php
                            if($v['wr_is_comment']){
                                for($i=0;$i<strlen($v['wr_comment_reply'])+1;$i++) {
                                    echo "<span class='gray'>[댓글]</span>";
                                }
                                echo ' '.$v['wr_content'];
                            } else {
                                echo ' '.$v['wr_subject'];
                            }
                            ?>
                        </td>
                        <td class="td_input">
                            <input type="text" id="wr_datetime_<?php echo $v['wr_id']?>" value="<?php echo $v['wr_datetime']?>" class="frm_input" />
                        </td>
                        <td class="td_input">
                            <?php if($v['wr_is_comment']) {?>
                                <?php echo '-';?>
                            <?php } else {?>
                                <input type="text" id="wr_last_<?php echo $v['wr_id']?>" value="<?php echo $v['wr_last']?>" class="frm_input" />
                            <?php
                            }?>
                        </td>
                        <td class="td_input">
                            <?php if($v['wr_is_comment']) {?>
                                <?php echo '-';?>
                            <?php } else {?>
                                <input type="text" id="wr_hit_<?php echo $v['wr_id']?>" value="<?php echo $v['wr_hit']?>" class="frm_input" />
                            <?php
                            }?>
                        </td>
                        <td class="td_mng">
                            <?php echo $v_mod ?>
                            <?php echo $u_mod ?>
                        </td>
                    </tr>
                    <?php
                }
            }
            ?>
            <?php if (count($list['list']) == 0) { echo '<tr><td colspan="'.$colspan.'" class="empty_table">게시물이 없습니다.</td></tr>'; } ?>
            </tbody>
        </table>
    </div>

    <div class="btn_fixed_top">
        <a href="<?php echo G5_URL ?>" class="btn btn_02">메인으로</a>
    </div>
</form>

<?php echo get_paging(G5_IS_MOBILE ? $config['cf_mobile_pages'] : $config['cf_write_pages'], $page, $total_page, '?' . $qstr . '&amp;page=' ,"&amp;bo_table={$bo_table}&s_wr_id={$s_wr_id}&s_wr_subject={$s_wr_subject}"); ?>

<script>
function update(bo_table, wr_id, wr_comment) {
    const wr_datetime = $('#wr_datetime_' + wr_id).val();
    const wr_last = $('#wr_last_' + wr_id).val();
    const wr_hit = $('#wr_hit_' + wr_id).val();

    if (!wr_comment) { // 댓글이 아니면
        if(!wr_datetime || !wr_last || !wr_hit) {
            alert('값이 없습니다.');
            return;
        }
    } else { // 댓글이라면
        if(!wr_datetime) {
            alert('값이 없습니다.');
            return;
        }
    }

    const token = get_ajax_token();
    if(!token) {
        alert("토큰 정보가 올바르지 않습니다.");
        return;
    }

    if(!confirm('게시글을 수정하시겠습니까?')) {
        return false;
    }

    $.post(
        './board_manage_list_ajax.php',
        {'bo_table':bo_table, 'wr_id': wr_id, 'wr_datetime':wr_datetime, 'wr_last':wr_last, 'wr_hit':wr_hit, 'token':token},
        function(data) {
            if(data == '200') {
                location.reload();
            } else {
                alert('Error:'+data);
            }
        }
    ).fail(
        function(xhr, ajaxOptions, thrownError) {
            alert(thrownError);
        }
    );
}
</script>

<?php
require_once G5_ADMIN_PATH.'/admin.tail.php';