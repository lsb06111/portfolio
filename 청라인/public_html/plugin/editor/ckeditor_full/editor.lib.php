<?php
if (!defined('_GNUBOARD_')) exit; // 개별 페이지 접근 불가

function editor_html($id, $content, $is_dhtml_editor=true)
{
    global $g5, $config, $w, $board;
    static $js = true;

    if( $is_dhtml_editor && $content && !$w && (isset($board['bo_insert_content']) && !empty($board['bo_insert_content']) ) ){       //글쓰기 기본 내용 처리
        if( preg_match('/\r|\n/', $content) && $content === strip_tags($content, '<a><strong><b>') ) {  //textarea로 작성되고, html 내용이 없다면
            $content = nl2br($content);
        }
    }

    $editor_url = G5_EDITOR_URL.'/ckeditor_full';

    $html = "";
    $html .= "<span class=\"sound_only\">웹에디터 시작</span>";

    if ($is_dhtml_editor && $js) {
        $html .= "\n".'<script src="'.$editor_url.'/ckeditor.js"></script>';
        $html .= "\n".'<script>var g5_editor_url = "'.$editor_url.'";</script>';
        $html .= "\n".'<script src="'.$editor_url.'/config.js"></script>';
        $js = false;
    }

    $ckeditor_class = $is_dhtml_editor ? "ckeditor" : "";
    $html .= "\n<textarea id=\"$id\" name=\"$id\" class=\"$ckeditor_class\" maxlength=\"65536\">$content</textarea>";
    $html .= "\n<span class=\"sound_only\">웹 에디터 끝</span>";
    return $html;
}


// textarea 로 값을 넘긴다. javascript 반드시 필요
function get_editor_js($id, $is_dhtml_editor=true)
{
    if ($is_dhtml_editor) {
        return "var {$id}_editor_data = CKEDITOR.instances.{$id}.getData();\n";
    } else {
        return "var {$id}_editor = document.getElementById('{$id}');\n";
    }
}


//  textarea 의 값이 비어 있는지 검사
function chk_editor_js($id, $is_dhtml_editor=true)
{
    if ($is_dhtml_editor) {
        return "if (!{$id}_editor_data) { alert(\"내용을 입력해 주십시오.\"); CKEDITOR.instances.{$id}.focus(); return false; }\nif (typeof(f.{$id})!=\"undefined\") f.{$id}.value = {$id}_editor_data;\n";
    } else {
        return "if (!{$id}_editor.value) { alert(\"내용을 입력해 주십시오.\"); {$id}_editor.focus(); return false; }\n";
    }
}
?>