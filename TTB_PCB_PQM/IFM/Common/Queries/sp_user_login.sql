CREATE DEFINER=`root`@`%` PROCEDURE `sp_user_login`(
	IN usercd varchar(20),
    IN pass varchar(32)
)
BEGIN
	SELECT u.user_cd,u.user_name,r.ClassName AS assign_code
	FROM app_db.m_user AS u
	JOIN app_db.m_role AS r
	ON u.user_cd=r.user_cd
	WHERE r.`status`=1
	AND u.user_cd=usercd
	AND u.user_pass=pass;
END