import React from "react";
import { routes } from './../../router/index';
import { Routes } from 'react-router-dom';
import { Route } from 'react-router-dom';
import Headre from "../layout/Header/Headre";

const AppRouter = () => {
  return (
    <div>
      <div style={{ margin: "10px" }}>
        <Headre/>
        <Routes path="/">
          {routes.map((rout) => (
            <Route
              exact={rout.exact}
              path={rout.path}
              element={rout.element}
              key={rout.path}
            ></Route>
          ))}
        </Routes>
      </div>
    </div>
  );
};

export default AppRouter;
