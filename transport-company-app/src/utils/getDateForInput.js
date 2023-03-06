export const getDateForInput = (date) => {
    if (date === null || date === ""){
      return "";
    }
    return `${`${date.getFullYear()}`}-${`${
      date.getMonth() + 1
    }`.padStart(2, "0")}-${`${date.getDate()}`.padStart(2, "0")}`;
  };
  