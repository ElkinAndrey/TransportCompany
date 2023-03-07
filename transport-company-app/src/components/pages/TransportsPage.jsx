import React from "react";
import PaginationBar from "../forms/paginationBar/PaginationBar";
import TransportTable from "./../../views/TransportTable/TransportTable";
import { useState } from "react";

const TransportsPage = () => {
  let [transportCount, setTransportCount] = useState(0);
  let [page, setPage] = useState(1);
  let [end, setEnd] = useState(1);

  return (
    <div>
      <div>Количество транспорта : {transportCount}</div>
      <PaginationBar start={1} end={end} page={page} setPage={setPage} />
      <TransportTable
        page={page}
        setPage={setPage}
        setEnd={setEnd}
        setTransportCount={setTransportCount}
      />
    </div>
  );
};

export default TransportsPage;
