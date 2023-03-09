import React from "react";
import { Link } from "react-router-dom";
import classes from "./TableLink.module.css";

const TableLink = ({ to, style }) => {
  return (
    <td style={style} className={classes.tdTableLink}>
      <Link to={to} className={classes.tableLink}></Link>
    </td>
  );
};

export default TableLink;
