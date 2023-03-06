import React, { useEffect } from "react";
import classes from "./PaginationBar.module.css";

const PaginationBar = ({ start, end, page, setPage }) => {
  let range = [];
  const size = 4;
  if (end - start >= (size + 1) * 2) {
    let s = page - size > start ? page - size : start + 1;
    let e = s + size * 2 < end ? s + size * 2 : end - 1;
    s = e - size * 2 > start ? e - size * 2 : start + 1;
    for (let i = s; i <= e; i++) {
      range.push(i);
    }
    if (start + 2 + size > page) {
      range.push(range[range.length - 1] + 1);
    }
    if (end - 2 - size < page) {
      range.unshift(range[0] - 1);
    }
    if (start + 2 === range[0]) {
      range.unshift(start + 1);
    }
    if (end - 2 === range[range.length - 1]) {
      range.push(end - 1);
    }
  } else {
    for (let i = start + 1; i <= end - 1; i++) {
      range.push(i);
    }
  }

  useEffect(() => {
    if (start > end) {
      let a = end;
      end = start;
      start = a;
    }
    if (page > end) {
      setPage(end);
    }
    if (page < start) {
      setPage(start);
    }
    console.log(1);
  }, []);
  return (
    <div className={classes.paginationBar}>
      <button
        className={classes.switch}
        onClick={() => {
          if (page > start) {
            setPage(page - 1);
          }
        }}
      >
        {"<"}
      </button>

      <button
        className={start === page ? classes.active : ""}
        onClick={() => setPage(start)}
      >
        {start}
      </button>

      {start + 1 !== range[0] && start + 1 < end && (
        <div className={classes.pass}>...</div>
      )}

      {range.map((p) => (
        <button
          key={p}
          className={p === page ? classes.active : ""}
          onClick={() => setPage(p)}
        >
          {p}
        </button>
      ))}

      {end - 1 !== range[range.length - 1] && start + 1 < end && (
        <div className={classes.pass}>...</div>
      )}

      {start !== end && (
        <button
          className={end === page ? classes.active : ""}
          onClick={() => setPage(end)}
        >
          {end}
        </button>
      )}

      <button
        className={classes.switch}
        onClick={() => {
          if (page < end) {
            setPage(page + 1);
          }
        }}
      >
        {">"}
      </button>
    </div>
  );
};

export default PaginationBar;
