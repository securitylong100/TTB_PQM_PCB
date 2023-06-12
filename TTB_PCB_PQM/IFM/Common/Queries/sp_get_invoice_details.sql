--CREATE DEFINER=`root`@`%` PROCEDURE `sp_get_invoice_details`(IN invoice_cd varchar(32))
--BEGIN
--SELECT `tbl_invoice`.`invoice_cd`,
--		`tbl_cpo`.`global_cd`,
--		`tbl_cpo`.`cpo_cd`,
--		`tbl_cpo`.`detail`,
--		`tbl_cpo`.`rev_date`,
--		`tbl_cpo`.`cfm_date`,
--		`tbl_cpo`.`ship_date`,
--		`tbl_cpo`.`cpo_state`,
--		`tbl_cpo_price`.`price`,
--		`tbl_cpo_price`.`discount`,
--		`tbl_invoice`.`exchange_rate`
--FROM `app_db`.`tbl_invoice`
--JOIN `app_db`.`tbl_cpo_price`
--ON `tbl_invoice`.`invoice_cd`=`tbl_cpo_price`.`invoice_cd`
--JOIN `app_db`.`tbl_cpo`
--ON `tbl_cpo`.`global_cd`=`tbl_cpo_price`.`global_cd`
--WHERE `tbl_cpo`.`status`<2
--AND `tbl_invoice`.`status`<2
--AND `tbl_cpo_price`.`status`<2
--AND (@invoice_cd IS NULL OR `tbl_invoice`.`invoice_cd`=@invoice_cd);
--END

CREATE DEFINER=`root`@`%` PROCEDURE `sp_get_invoice_details`(IN invoice_cd varchar(255))
BEGIN
SET @sql = CONCAT('SELECT `tbl_invoice`.`invoice_cd`,
						`tbl_cpo`.`global_cd`,
						`tbl_cpo`.`cpo_cd`,
						`tbl_cpo`.`detail`,
						`tbl_cpo`.`rev_date`,
						`tbl_cpo`.`cfm_date`,
						`tbl_cpo`.`ship_date`,
						`tbl_cpo`.`cpo_state`,
						`tbl_cpo_price`.`price`,
						`tbl_cpo_price`.`discount`,
						`tbl_invoice`.`exchange_rate`
				FROM `app_db`.`tbl_invoice`
				JOIN `app_db`.`tbl_cpo_price`
				ON `tbl_invoice`.`invoice_cd`=`tbl_cpo_price`.`invoice_cd`
				JOIN `app_db`.`tbl_cpo`
				ON `tbl_cpo`.`global_cd`=`tbl_cpo_price`.`global_cd`
				WHERE `tbl_cpo`.`status`<2
				AND `tbl_invoice`.`status`<2
				AND `tbl_cpo_price`.`status`<2
				AND (',invoice_cd,' IS NULL OR `tbl_invoice`.`invoice_cd` IN (',invoice_cd,'));');
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
END