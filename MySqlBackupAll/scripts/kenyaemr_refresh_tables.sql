SET FOREIGN_KEY_CHECKS=0;
call create_etl_tables();

SET FOREIGN_KEY_CHECKS=0;
call sp_first_time_setup();

SET FOREIGN_KEY_CHECKS=0;
call create_datatools_tables();

SET FOREIGN_KEY_CHECKS=1;