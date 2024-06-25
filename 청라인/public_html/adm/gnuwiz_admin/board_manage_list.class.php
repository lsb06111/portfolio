<?php
class BOARD_MANAGE_LIST {

    public $rows		= 0;
    public $page		= 1;
    public $from_record	= 0;
    public $sst	        = "wr_datetime";
    public $sod	        = "desc";
    public $sql_search  = "where 1=1";
    public $sql_order   = "";
    public $bo_table;
    public $write_table;
    public $g5;

    function __construct()
    {
        global $g5;
        $this->g5 = $g5;
        $this->sql_order = " order by {$this->sst} {$this->sod} ";
    }

    public function set_bo_table($bo_table) {
        $this->bo_table = $bo_table;
        $this->write_table = $this->g5['write_prefix'].$bo_table;
    }

    //중복체크
    public function check($title)
    {
    }

    //등록 및 수정
    public function write($opt) {

        if(!$this->bo_table) return false;

        //등록 or 수정 체크
        $w = "";
        if($opt['wr_id']!='') {
            $w = "u";
            $wr_id = intval($opt['wr_id']);
        }

        //처리
        if($w=="") {
            $q = "insert into ".$this->write_table." set ";
        } else {
            $q = "update ".$this->write_table." set ";
            unset($opt['wr_id']);
        }

        foreach($opt as $k=>$v){
            $q .= " ".$k." = '".$v."',";
        }

        $q = substr($q,0,-1);

        if($w=='') {
            $q .= "";
        } else {
            $q .= " where wr_id='{$wr_id}'";
        }
        sql_query($q);

        //고유값 리턴
        if($w=='') {
            $wr_id = sql_insert_id();
        }

        return $wr_id;
    }

    //목록 가져와서 배열로 반환
    public function lists($opt) {
        if($opt['s_wr_id']) $this->sql_search .= " and wr_id = '{$opt['s_wr_id']}' ";
        if($opt['s_wr_subject']) $this->sql_search .= " and wr_subject like '%{$opt['s_wr_subject']}%' ";

        if(!$this->bo_table) {
            $board_list = $this->get_board_list();
            $sql = array();
            for ($i=0; $i<count($board_list); $i++) {
                $sql[] = " (select *, '{$board_list[$i]['bo_table']}' as bo_table, '{$board_list[$i]['bo_subject']}' as bo_subject from g5_write_{$board_list[$i]['bo_table']} {$this->sql_search}) ";
            }
            $full_sql = implode("UNION ALL", $sql);

            $sql = " select count(*) as cnt from (".$full_sql.") as a {$this->sql_order} ";
            $row = union_sql_fetch($sql);
            $total_count = $row['cnt'];

            $sql = " select * from (".$full_sql.") as a {$this->sql_order} limit {$this->from_record}, {$this->rows} ";
            $result = union_sql_query($sql);

            $list = array();
            while ($row = sql_fetch_array($result)) {
                $list[] = $row;
            }

        } else {
            $sql = " select count(*) as cnt from {$this->write_table} {$this->sql_search} {$this->sql_order} ";
            $row = sql_fetch($sql);
            $total_count = $row['cnt'];

            $sql = " select * from {$this->write_table} {$this->sql_search} {$this->sql_order} limit {$this->from_record}, {$this->rows} ";
            $result = sql_query($sql);

            $list = array();
            while ($row = sql_fetch_array($result)) {
                $row['bo_table'] = $this->bo_table;
                $list[] = $row;
            }
        }

        if($opt['simple_wr_content']) {
            if(count($list)) {
                foreach($list as $k => $v) {
                    $list[$k]['wr_content'] = strip_tags($v['wr_content']);
                    $list[$k]['wr_content'] = trim(preg_replace('/\s+/', '', $list[$k]['wr_content']));
                    $list[$k]['wr_content'] = cut_str($list[$k]['wr_content'],40);
                }
            }
        }

        $total_page  = ceil($total_count / $this->rows);  // 전체 페이지 계산
        if ($this->page < 1) {
            $this->page = 1; // 페이지가 없으면 첫 페이지 (1 페이지)
        }
        $this->from_record = ($this->page - 1) * $this->rows; // 시작 열을 구함

        $res['list'] = $list;
        $res['total_count'] = $total_count;
        $res['total_page'] = $total_page;

        return $res;
    }

    //전체 게시판 목록 불러오기
    public function get_board_list() {
        $q = " SELECT bo_table, bo_subject FROM ".$this->g5['board_table']." ORDER BY bo_subject ASC ";
        $q_result = sql_query($q);
        $list = array();
        while($row = sql_fetch_array($q_result)) {
            $list[] = $row;
        }
        return $list;
    }
}
