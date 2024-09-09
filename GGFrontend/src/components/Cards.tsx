import { useState } from "react";

export default function Cards() {
  const [count, setCount] = useState(0);
  const [countTwo, setCountTwo] = useState(0);

  return (
    <>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
      </div>
      <div className="card">
        <button onClick={() => setCountTwo((countTwo) => countTwo + 1)}>
          count is {countTwo}
        </button>
      </div>
      <div className="card">
        <button
          onClick={() => {
            setCountTwo(0);
            setCount(0);
          }}
        >
          reset count
        </button>
      </div>
    </>
  );
}
