import React from 'react'
import classes from "./Header.module.css";
import { Link } from "react-router-dom";

const Header = () => {
  return (
    <div className={classes.body}>
        <div><Link to={"/transport"} className={classes.button}>Транспорт</Link></div>
        <div><Link to={"/alltransport"} className={classes.button}>Весь транспорт</Link></div>
        <div><Link to={"/person"} className={classes.button}>Персонал</Link></div>
        <div><Link to={"/region"} className={classes.button}>Подчиненность</Link></div>
    </div>
  )
}

export default Header