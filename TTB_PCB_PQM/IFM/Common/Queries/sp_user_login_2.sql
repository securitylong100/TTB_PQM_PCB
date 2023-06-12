DELIMITER $$
CREATE DEFINER=`root`@`%` PROCEDURE `sp_user_login_2`(
	IN usercd varchar(20),
    IN pass varchar(32)
)
BEGIN
	SELECT u.user_cd,u.user_name,r.assign_code,u.user_lang
	FROM app_db.m_user AS u
	JOIN app_db.m_user_roles AS r
	ON u.user_cd=r.user_cd
	WHERE 1=1
	AND u.user_cd=usercd
	AND u.user_pass=pass;
END$$
DELIMITER ;
