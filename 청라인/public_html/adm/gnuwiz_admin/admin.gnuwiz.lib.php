<?php
if (!defined('_GNUBOARD_')) exit;

// 전체 게시판을 SELECT 형식으로 얻음 (gnuwiz)
// $name = select id&name
// $event = required
// $class = css class name
function get_board_select($name, $selected = '', $event='', $class='')
{
    global $g5;

    $sql = " select * from {$g5['board_table']} order by bo_table asc ";
    $result = sql_query($sql);
    $str = '<select id="' . $name . '" name="' . $name . '" class="' . $class . '"' . $event . '><option value="">선택</option>';
    for ($i=0; $row=sql_fetch_array($result); $i++) {
        $str .= '<option value="'.$row['bo_table'].'"'.get_selected($row['bo_table'], $selected).'>'.$row['bo_table'].' ('.$row['bo_subject'].')</option>';
        $str .='';
    }
    $str .= '</select>';
    return $str;
}

// sql_query()함수는 union이 사용이 불가능하여 새로운 함수로 대처 (gnuwiz)
function union_sql_query($sql, $error=G5_DISPLAY_SQL_ERROR, $link=null)
{
    global $g5;

    if(!$link)
        $link = $g5['connect_db'];

    // Blind SQL Injection 취약점 해결
    $sql = trim($sql);
    // union의 사용을 허락하지 않습니다.
    //$sql = preg_replace("#^select.*from.*union.*#i", "select 1", $sql);
    //$sql = preg_replace("#^select.*from.*[\s\(]+union[\s\)]+.*#i ", "select 1", $sql);
    // `information_schema` DB로의 접근을 허락하지 않습니다.
    $sql = preg_replace("#^select.*from.*where.*`?information_schema`?.*#i", "select 1", $sql);

    $is_debug = get_permission_debug_show();

    $start_time = $is_debug ? get_microtime() : 0;

    if(function_exists('mysqli_query') && G5_MYSQLI_USE) {
        if ($error) {
            $result = @mysqli_query($link, $sql) or die("<p>$sql<p>" . mysqli_errno($link) . " : " .  mysqli_error($link) . "<p>error file : {$_SERVER['SCRIPT_NAME']}");
        } else {
            try {
                $result = @mysqli_query($link, $sql);
            } catch (Exception $e) {
                $result = null;
            }
        }
    } else {
        if ($error) {
            $result = @mysql_query($sql, $link) or die("<p>$sql<p>" . mysql_errno() . " : " .  mysql_error() . "<p>error file : {$_SERVER['SCRIPT_NAME']}");
        } else {
            $result = @mysql_query($sql, $link);
        }
    }

    $end_time = $is_debug ? get_microtime() : 0;

    if($result && $is_debug) {
        // 여기에 실행한 sql문을 화면에 표시하는 로직 넣기
        $g5_debug['sql'][] = array(
            'sql' => $sql,
            'start_time' => $start_time,
            'end_time' => $end_time,
        );
    }

    run_event('union_sql_query_after', $result, $sql, $start_time, $end_time);

    return $result;
}

// sql_fetch()함수는 union이 사용이 불가능하여 새로운 함수로 대처 (gnuwiz)
function union_sql_fetch($sql, $error=G5_DISPLAY_SQL_ERROR, $link=null)
{
    global $g5;

    if(!$link)
        $link = $g5['connect_db'];

    $result = mysqli_query($link, $sql);
    $row = mysqli_fetch_assoc($result);

    return $row;
}