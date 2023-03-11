import React from "react";
import classes from "./Modal.module.css";

const Modal = ({ active, setActive, children }) => {
  return (
    <div
      className={active ? classes.modal + " " + classes.active : classes.modal}
      onMouseDown={() => setActive(false)}
    >
      <div
        className={
          active
            ? classes.modal__content + " " + classes.active
            : classes.modal__content
        }
        onMouseDown={(e) => e.stopPropagation()}
      >
        {children}
      </div>
    </div>
  );
};

export default Modal;
