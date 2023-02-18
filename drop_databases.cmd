@echo off

echo Updating databases for all API projects...

for /d %%d in (*API*) do (
  echo Updating database for project: %%d
  pushd "%%d"
  dotnet ef database drop --force
  popd
)

echo All databases updated.
