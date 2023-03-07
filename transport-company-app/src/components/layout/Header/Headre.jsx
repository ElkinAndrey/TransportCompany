import React from 'react'
import classes from "./Headre.module.css";
import { Link } from "react-router-dom";

const Headre = () => {
  return (
    <div className={classes.body}>
        <div><Link to={"transport"} className={classes.button}>Транспорт</Link></div>
        <div><Link to={"person"} className={classes.button}>Персонал</Link></div>
    </div>
  )
}

export default Headre