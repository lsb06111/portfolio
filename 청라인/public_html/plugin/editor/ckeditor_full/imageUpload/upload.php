<?php
include_once("_common.php");

if(strpos($config['cf_editor'], 'ckeditor') === false ){
    exit;
}

// ---------------------------------------------------------------------------

# 이미지가 저장될 디렉토리의 전체 경로를 설정합니다.
# 끝에 슬래쉬(/)는 붙이지 않습니다.
# 주의: 이 경로의 접근 권한은 쓰기, 읽기가 가능하도록 설정해 주십시오.

# data/editor 디렉토리가 없는 경우가 있을수 있으므로 디렉토리를 생성하는 코드를 추가함. kagla 140305

@mkdir(G5_DATA_PATH.'/'.G5_EDITOR_DIR, G5_DIR_PERMISSION);
@chmod(G5_DATA_PATH.'/'.G5_EDITOR_DIR, G5_DIR_PERMISSION);

$ym = date('ym', G5_SERVER_TIME);

$data_dir = G5_DATA_PATH.'/'.G5_EDITOR_DIR.'/'.$ym;
$data_url = G5_DATA_URL.'/'.G5_EDITOR_DIR.'/'.$ym;

define("SAVE_DIR", $data_dir);

@mkdir(SAVE_DIR, G5_DIR_PERMISSION);
@chmod(SAVE_DIR, G5_DIR_PERMISSION);

# 위에서 설정한 'SAVE_DIR'의 URL을 설정합니다.
# 끝에 슬래쉬(/)는 붙이지 않습니다.

define("SAVE_URL", $data_url);

function cke_get_user_id ()
{
    @session_start();
    return session_id();
}

function cke_get_file_passname ()
{
    $tmp_name = cke_get_user_id().$_SERVER['REMOTE_ADDR'];
    $tmp_name = md5(sha1($tmp_name));
    return $tmp_name;
}

function cke_generateRandomString ($length = 4)
{
    $characters = '0123456789abcdefghijklmnopqrstuvwxyz';
    $charactersLength = strlen($characters);
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, $charactersLength - 1)];
    }
    return $randomString;
}

function cke_replace_filename ($filename)
{
    $ext = pathinfo($filename, PATHINFO_EXTENSION);
    $random_str = cke_generateRandomString(4);
    $passname = cke_get_file_passname();
    $file_arr = date("YmdHis", time());
    return $file_arr.'_'.$passname.'_'.$random_str.'.'.$ext;
}
 
// 업로드 DIALOG 에서 전송된 값
$funcNum = $_GET['CKEditorFuncNum'];
$CKEditor = $_GET['CKEditor'];
$langCode = $_GET['langCode'];

$tempfile = $_FILES['upload']['tmp_name'];
$filename = $_FILES['upload']['name'];

$type = substr($filename, strrpos($filename, ".")+1);
$found = false;
switch ($type) {
    case "jpg":
    case "jpeg":
    case "gif":
    case "png":
        $found = true;
}

if ($found != true) {
    exit;
}

// 저장 파일 이름: 년월일시분초_렌덤문자
// 20140327125959_abcdefghi.jpg

$filename = cke_replace_filename($filename);
$savefile = SAVE_DIR . '/' . $filename;
$save_url = SAVE_URL . '/' . $filename;

move_uploaded_file($tempfile, $savefile);
$imgsize = getimagesize($savefile);
$filesize = filesize($savefile);

if (!$imgsize) {
    $filesize = 0;
    $random_name = '-ERR';
    unlink($savefile);
};

try {
    if(defined('G5_FILE_PERMISSION')) chmod($savefile, G5_FILE_PERMISSION);
} catch (Exception $e) {

}

echo "<script>window.parent.CKEDITOR.tools.callFunction($funcNum, $save_url, '업로드완료');</script>";
?>