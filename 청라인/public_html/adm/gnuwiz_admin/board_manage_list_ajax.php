<?php
$sub_menu = "600400";
require_once './_common.php';
require_once './board_manage_list.class.php';

auth_check_menu($auth, $sub_menu, 'w');

check_admin_token();

$bo_table = isset($_POST['bo_table']) ? preg_replace('/[^a-z0-9_]/i', '', $_POST['bo_table']) : '';
$wr_id = isset($_POST['wr_id']) ? (int) $_POST['wr_id'] : 0;
$wr_datetime = isset($_POST['wr_datetime']) ? $_POST['wr_datetime'] : '';
$wr_last = isset($_POST['wr_last']) ? $_POST['wr_last'] : '';
$wr_hit = isset($_POST['wr_hit']) ? $_POST['wr_hit'] : 0;


// 점검
if (!isset($bo_table)) {
    die('200');
}

if (!isset($wr_id)) {
    die('201');
}

if (!isset($wr_datetime) || !isset($wr_last) || !isset($wr_hit)) {
    die('202');
}

// 설정
$board_manage_list = new BOARD_MANAGE_LIST();
$board_manage_list->set_bo_table($bo_table);

// 변경
unset($opt);
$opt['wr_id'] = $wr_id;
$opt['wr_datetime'] = $wr_datetime;
$opt['wr_last'] = $wr_last;
$opt['wr_hit'] = $wr_hit;
$board_manage_list->write($opt);

// 성공
die('200');