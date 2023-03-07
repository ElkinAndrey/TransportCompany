import React, { useState } from "react";
import PersonTable from "../../views/PersonTable/PersonTable";
import PaginationBar from "./../forms/paginationBar/PaginationBar";

const PersonsPage = () => {
  let [personCount, setPersonCount] = useState(0);
  let [page, setPage] = useState(1);
  let [end, setEnd] = useState(1);

  return (
    <div>
      <div>Количество человек : {personCount}</div>
      <PaginationBar start={1} end={end} page={page} setPage={setPage} />
      <PersonTable
        page={page}
        setPage={setPage}
        setEnd={setEnd}
        setPersonCount={setPersonCount}
      />
    </div>
  );
};

export default PersonsPage;
