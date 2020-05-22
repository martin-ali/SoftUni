/**
 * @param {{ dizziness: boolean; levelOfHydrated: number; experience: number; weight: number; }} worker
 */
function healWorker(worker)
{
    if (worker.dizziness)
    {
        worker.levelOfHydrated += worker.experience * worker.weight * 0.1;
        worker.dizziness = false;
    }

    return worker;
}