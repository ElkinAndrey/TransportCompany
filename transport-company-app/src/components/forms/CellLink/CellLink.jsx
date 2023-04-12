import React from "react";
import classes from "./CellLink.module.css";
import { Link } from 'react-router-dom';

const CellLink = ({ children, to, style, rowspan }) => {
  return (
    <td style={style} rowspan={rowspan} className={classes.tdCellLink}>
      {children}
      <Link to={to} className={classes.cellLink}></Link>
    </td>
  );
};

export default CellLink;
